using GTA;
using GTA.Math;
using HotWheelsVehicleTheftJobs.Core;
using HotWheelsVehicleTheftJobs.Data;
using HotWheelsVehicleTheftJobs.UI;

namespace HotWheelsVehicleTheftJobs.Systems
{
    public class HighValueMissionSpawner
    {
        public Mission CreateMission()
        {
            Model vehicleModel =
                new Model(HighValueMissionData.VehicleHash);

            if (!vehicleModel.IsInCdImage ||
                !vehicleModel.IsVehicle)
            {
                return null;
            }

            vehicleModel.Request(5000);

            if (!vehicleModel.IsLoaded)
                return null;

            // Spawn slightly above the configured location
            Vector3 spawnLocation =
                new Vector3(
                    HighValueMissionData.SpawnLocation.X,
                    HighValueMissionData.SpawnLocation.Y,
                    HighValueMissionData.SpawnLocation.Z + 2.0f
                );

            Vehicle vehicle = Vehicle.Create(
                vehicleModel,
                spawnLocation,
                90.0f
            );

            vehicleModel.MarkAsNoLongerNeeded();

            if (vehicle == null || !vehicle.Exists())
                return null;

            vehicle.IsPersistent = true;
            vehicle.IsInvincible = false;
            vehicle.IsUndriveable = false;

            // Place the tank correctly on the ground
            vehicle.PlaceOnGround();

            // Remove pitch and roll so it starts upright
            vehicle.Rotation =
                new Vector3(
                    0.0f,
                    0.0f,
                    vehicle.Rotation.Z
                );

            Blip vehicleBlip =
                BlipHelper.CreateHighValueVehicleBlip(
                    vehicle
                );

            Mission mission = new Mission
            {
                TargetVehicle = vehicle,

                TargetVehicleBlip =
                    vehicleBlip,

                VehicleSpawnLocation =
                    spawnLocation,

                DeliveryLocation =
                    HighValueMissionData.DeliveryLocation,

                SalePrice =
                    HighValueMissionData.SalePrice,

                VehicleType =
                    TargetVehicleType.Car,

                MissionType =
                    MissionType.HighValueMilitaryTheft,

                WantedLevel =
                    HighValueMissionData.WantedLevel,

                State =
                    MissionState.MissionAvailable,

                TheftStarted = false,

                PoliceLost = false
            };

            return mission;
        }
    }
}