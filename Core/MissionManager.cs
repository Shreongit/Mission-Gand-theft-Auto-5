using System;
using System.Windows.Forms;
using GTA;
using HotWheelsVehicleTheftJobs.Config;
using HotWheelsVehicleTheftJobs.Data;
using HotWheelsVehicleTheftJobs.Systems;
using HotWheelsVehicleTheftJobs.UI;
using HotWheelsVehicleTheftJobs.Utils;

namespace HotWheelsVehicleTheftJobs.Core
{
    public class MissionManager
    {
        private Mission _currentMission;

        private readonly VehicleMissionSpawner _vehicleMissionSpawner;
        private readonly HighValueMissionSpawner _highValueMissionSpawner;
        private readonly MissionScheduler _missionScheduler;
        private readonly PoliceSystem _policeSystem;
        private readonly DeliverySystem _deliverySystem;
        private readonly RewardSystem _rewardSystem;

        private int _lastMissionEndTime;
        private bool _waitingForNextMission;

        public MissionManager()
        {
            _vehicleMissionSpawner =
                new VehicleMissionSpawner();

            _highValueMissionSpawner =
                new HighValueMissionSpawner();

            _missionScheduler =
                new MissionScheduler();

            _policeSystem =
                new PoliceSystem();

            _deliverySystem =
                new DeliverySystem();

            _rewardSystem =
                new RewardSystem();

            _lastMissionEndTime = Game.GameTime;
            _waitingForNextMission = true;
        }

        public void Update()
        {
            if (_currentMission == null)
            {
                UpdateMissionCooldown();
                return;
            }

            switch (_currentMission.State)
            {
                case MissionState.MissionAvailable:
                    UpdateMissionAvailable();
                    break;

                case MissionState.VehicleStolen:
                    UpdateVehicleStolen();
                    break;

                case MissionState.DeliveringVehicle:
                    UpdateDeliveringVehicle();
                    break;

                case MissionState.ReadyToSell:
                    UpdateReadyToSell();
                    break;
            }
        }

        public void HandleKeyPress(Keys key)
        {
            if (_currentMission == null)
                return;

            if (_currentMission.State !=
                MissionState.ReadyToSell)
            {
                return;
            }

            if (key == Keys.E)
            {
                CompleteMission();
            }
        }

        private void UpdateMissionCooldown()
        {
            if (!_waitingForNextMission)
                return;

            int elapsedTime =
                Game.GameTime - _lastMissionEndTime;

            if (elapsedTime <
                MissionConfig.MissionCooldownMilliseconds)
            {
                return;
            }

            StartNextMission();
        }

        private void StartNextMission()
        {
            if (_missionScheduler.ShouldStartHighValueMission())
            {
                _currentMission =
                    _highValueMissionSpawner.CreateMission();

                if (_currentMission != null)
                {
                    NotificationHelper.Show(
                        HighValueMissionData.MissionAvailableMessage
                    );
                }
            }
            else
            {
                _currentMission =
                    _vehicleMissionSpawner.CreateMission();

                if (_currentMission != null)
                {
                    NotificationHelper.Show(
                        MissionConfig.VehicleAvailableMessage
                    );
                }
            }

            if (_currentMission != null)
            {
                _waitingForNextMission = false;
            }
        }

        private void UpdateMissionAvailable()
        {
            if (!IsMissionVehicleValid())
            {
                FailMission(
                    MissionConfig.MissionFailedVehicleDestroyed
                );
                return;
            }

            Ped player =
                Game.Player.Character;

            if (player.IsInVehicle(
                _currentMission.TargetVehicle))
            {
                StartVehicleTheft();
            }
        }

        private void StartVehicleTheft()
        {
            _currentMission.TheftStarted = true;

            BlipHelper.Remove(
                _currentMission.TargetVehicleBlip
            );

            _currentMission.TargetVehicleBlip = null;

            _policeSystem.StartWantedLevel(
                _currentMission.WantedLevel
            );

            _currentMission.State =
                MissionState.VehicleStolen;

            if (_currentMission.IsHighValueMission)
            {
                NotificationHelper.Show(
                    HighValueMissionData.VehicleStolenMessage
                );
            }
            else
            {
                NotificationHelper.Show(
                    MissionConfig.VehicleStolenMessage
                );
            }
        }

        private void UpdateVehicleStolen()
        {
            if (!IsMissionVehicleValid())
            {
                FailMission(
                    MissionConfig.MissionFailedVehicleDestroyed
                );
                return;
            }

            if (_policeSystem.HasLostPolice())
            {
                _currentMission.PoliceLost = true;

                StartDelivery();

                _currentMission.State =
                    MissionState.DeliveringVehicle;
            }
        }

        private void StartDelivery()
        {
            if (_currentMission.IsHighValueMission)
            {
                _currentMission.DealershipBlip =
                    BlipHelper.CreateHighValueDeliveryBlip(
                        _currentMission.DeliveryLocation
                    );

                NotificationHelper.Show(
                    HighValueMissionData.PoliceLostMessage
                );
            }
            else
            {
                _deliverySystem.ActivateDelivery(
                    _currentMission
                );

                NotificationHelper.Show(
                    MissionConfig.CopsLostMessage
                );
            }
        }

        private void UpdateDeliveringVehicle()
        {
            if (!IsMissionVehicleValid())
            {
                FailMission(
                    MissionConfig.MissionFailedVehicleDestroyed
                );
                return;
            }

            _deliverySystem.DrawDeliveryMarker(
                _currentMission
            );

            if (_deliverySystem.IsVehicleAtDeliveryLocation(
                _currentMission))
            {
                _currentMission.State =
                    MissionState.ReadyToSell;
            }
        }

        private void UpdateReadyToSell()
        {
            if (!IsMissionVehicleValid())
            {
                FailMission(
                    MissionConfig.MissionFailedVehicleDestroyed
                );
                return;
            }

            _deliverySystem.DrawSellMarker(
                _currentMission
            );

            if (_currentMission.IsHighValueMission)
            {
                ShowHighValueSellPrompt();
            }
            else
            {
                _deliverySystem.ShowSellPrompt(
                    _currentMission
                );
            }
        }

        private void ShowHighValueSellPrompt()
        {
            Ped player =
                Game.Player.Character;

            if (!player.IsInVehicle(
                _currentMission.TargetVehicle))
            {
                return;
            }

            float distance =
                _currentMission.TargetVehicle.Position.DistanceTo(
                    _currentMission.DeliveryLocation
                );

            if (distance >
                MissionConfig.SellInteractionRadius)
            {
                return;
            }

            string message =
                string.Format(
                    HighValueMissionData.SellPromptFormat,
                    _currentMission.SalePrice
                );

            NotificationHelper.ShowHelpText(
                message
            );
        }

        private void CompleteMission()
        {
            if (_currentMission == null)
                return;

            int reward =
                _rewardSystem.GetReward(
                    _currentMission
                );

            Game.Player.Money += reward;

            if (_currentMission.IsHighValueMission)
            {
                NotificationHelper.Show(
                    string.Format(
                        "Military vehicle sold for ~g~${0:N0}~s~!",
                        reward
                    )
                );
            }
            else
            {
                NotificationHelper.Show(
                    string.Format(
                        "Vehicle sold for ~g~${0:N0}~s~!",
                        reward
                    )
                );
            }

            _missionScheduler.RegisterMissionCompleted(
                _currentMission
            );

            EntityCleanup.CleanupMission(
                _currentMission
            );

            _currentMission = null;

            _lastMissionEndTime =
                Game.GameTime;

            _waitingForNextMission = true;
        }

        private void FailMission(string reason)
        {
            NotificationHelper.Show(reason);

            if (_currentMission != null)
            {
                EntityCleanup.CleanupMission(
                    _currentMission
                );
            }

            _currentMission = null;

            _lastMissionEndTime =
                Game.GameTime;

            _waitingForNextMission = true;
        }

        private bool IsMissionVehicleValid()
        {
            return _currentMission != null &&
                   _currentMission.TargetVehicle != null &&
                   _currentMission.TargetVehicle.Exists() &&
                   !_currentMission.TargetVehicle.IsDead;
        }

        public void Dispose()
        {
            if (_currentMission != null)
            {
                EntityCleanup.CleanupMission(
                    _currentMission
                );

                _currentMission = null;
            }

            _policeSystem.ClearWantedLevel();
        }
    }
}