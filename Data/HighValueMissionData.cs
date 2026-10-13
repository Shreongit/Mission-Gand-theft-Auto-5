using GTA;
using GTA.Math;

namespace HotWheelsVehicleTheftJobs.Data
{
    public static class HighValueMissionData
    {
        // Military vehicle
        public static readonly VehicleHash VehicleHash =
            VehicleHash.Rhino;

        // High-value reward
        public const int SalePrice = 500000;

        // Fort Zancudo tank spawn location
        public static readonly Vector3 SpawnLocation =
            new Vector3(-2360.72f, 3245.96f, 32.81f);

        // Sandy Shores Airfield hangar delivery location
        public static readonly Vector3 DeliveryLocation =
            new Vector3(1742.25f, 3299.48f, 41.15f);

        // 5-star wanted level
        public const int WantedLevel = 5;

        public const string MissionBlipName =
            "High-Value Military Vehicle";

        public const string DeliveryBlipName =
            "Sandy Shores Airfield Hangar";

        public const string MissionAvailableMessage =
            "A ~r~HIGH-VALUE MILITARY TARGET~s~ has been located. Check your map.";

        public const string VehicleStolenMessage =
            "Military vehicle stolen! ~r~Lose the police.~s~";

        public const string PoliceLostMessage =
            "The police are gone. Deliver the military vehicle to ~y~Sandy Shores Airfield.~s~";

        public const string SellPromptFormat =
            "Press ~INPUT_CONTEXT~ to sell the military vehicle for ~g~${0:N0}~s~.";
    }
}