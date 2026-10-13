using GTA;
using GTA.Math;
using HotWheelsVehicleTheftJobs.Config;
using HotWheelsVehicleTheftJobs.Data;

namespace HotWheelsVehicleTheftJobs.UI
{
    public static class BlipHelper
    {
        public static Blip CreateTargetVehicleBlip(
            Vehicle vehicle,
            TargetVehicleType vehicleType)
        {
            if (vehicle == null || !vehicle.Exists())
                return null;

            Blip blip = vehicle.AddBlip();

            if (vehicleType == TargetVehicleType.Bike)
            {
                blip.Sprite =
                    (BlipSprite)MissionConfig.TargetBikeBlipSprite;

                blip.Name =
                    MissionConfig.TargetBikeBlipName;
            }
            else
            {
                blip.Sprite =
                    (BlipSprite)MissionConfig.TargetVehicleBlipSprite;

                blip.Name =
                    MissionConfig.TargetVehicleBlipName;
            }

            blip.Color =
                (BlipColor)MissionConfig.YellowBlipColor;

            blip.IsShortRange = false;

            return blip;
        }

        public static Blip CreateHighValueVehicleBlip(
            Vehicle vehicle)
        {
            if (vehicle == null || !vehicle.Exists())
                return null;

            Blip blip = vehicle.AddBlip();

            // Tank / military vehicle blip
            blip.Sprite =
                (BlipSprite)421;

            // Red blip for high-value mission
            blip.Color =
                (BlipColor)1;

            blip.Name =
                "High-Value Military Target";

            blip.IsShortRange = false;

            return blip;
        }

        public static Blip CreateDealershipBlip(
            Vector3 location)
        {
            Blip blip = Blip.Create(location);

            blip.Sprite =
                (BlipSprite)MissionConfig.DealershipBlipSprite;

            blip.Color =
                (BlipColor)MissionConfig.DealershipBlipColor;

            blip.Name =
                MissionConfig.DealershipBlipName;

            blip.IsShortRange = false;

            blip.ShowRoute = true;

            return blip;
        }

        public static Blip CreateHighValueDeliveryBlip(
            Vector3 location)
        {
            Blip blip = Blip.Create(location);

            // Hangar / destination blip
            blip.Sprite =
                (BlipSprite)569;

            // Yellow destination blip
            blip.Color =
                (BlipColor)MissionConfig.YellowBlipColor;

            blip.Name =
                "Sandy Shores Airfield Hangar";

            blip.IsShortRange = false;

            // Automatically create GPS route
            blip.ShowRoute = true;

            return blip;
        }

        public static void Remove(Blip blip)
        {
            if (blip == null)
                return;

            if (blip.Exists())
            {
                blip.ShowRoute = false;
                blip.Delete();
            }
        }
    }
}