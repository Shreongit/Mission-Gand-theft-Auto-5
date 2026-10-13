using GTA;
using GTA.Math;
using HotWheelsVehicleTheftJobs.Config;
using HotWheelsVehicleTheftJobs.Core;
using HotWheelsVehicleTheftJobs.UI;

namespace HotWheelsVehicleTheftJobs.Systems
{
    public class DeliverySystem
    {
        public void ActivateDelivery(Mission mission)
        {
            if (mission == null)
                return;

            mission.DeliveryLocation =
                MissionConfig.SimeonDeliveryMarkerLocation;

            mission.DealershipBlip =
                BlipHelper.CreateDealershipBlip(
                    mission.DeliveryLocation
                );
        }

        public bool IsVehicleAtDeliveryLocation(Mission mission)
        {
            if (mission == null ||
                mission.TargetVehicle == null ||
                !mission.TargetVehicle.Exists())
            {
                return false;
            }

            Ped player = Game.Player.Character;

            if (!player.IsInVehicle(mission.TargetVehicle))
                return false;

            float distance =
                mission.TargetVehicle.Position.DistanceTo(
                    mission.DeliveryLocation
                );

            return distance <= MissionConfig.DeliveryRadius;
        }

        public void DrawDeliveryMarker(Mission mission)
        {
            if (mission == null)
                return;

            MarkerHelper.DrawDeliveryMarker(
                mission.DeliveryLocation
            );
        }

        public void DrawSellMarker(Mission mission)
        {
            if (mission == null)
                return;

            MarkerHelper.DrawDeliveryMarker(
                mission.DeliveryLocation
            );
        }

        public void ShowSellPrompt(Mission mission)
        {
            if (mission == null)
                return;

            Ped player = Game.Player.Character;

            if (!player.IsInVehicle(mission.TargetVehicle))
                return;

            float distance =
                mission.TargetVehicle.Position.DistanceTo(
                    mission.DeliveryLocation
                );

            if (distance > MissionConfig.SellInteractionRadius)
                return;

            string message = string.Format(
                MissionConfig.SellPromptFormat,
                mission.SalePrice
            );

            NotificationHelper.ShowHelpText(message);
        }
    }
}