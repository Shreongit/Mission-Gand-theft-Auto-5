using GTA.Math;

namespace HotWheelsVehicleTheftJobs.Config
{
    public static class MissionConfig
    {
        public const string ModName =
            "Hot Wheels: Vehicle Theft Jobs";

        public const int WantedLevel = 3;

        public const int MissionCooldownMilliseconds =
            30000;

        public const float VehicleSpawnDistance =
            2.0f;

        public const float DeliveryRadius =
            12.0f;

        public const float SellInteractionRadius =
            8.0f;

        public const float MissionVehicleCheckDistance =
            150.0f;

        // Premium Deluxe Motorsport outside parking lot
        public static readonly Vector3 SimeonDealershipLocation =
            new Vector3(-31.50f, -1090.00f, 26.42f);

        public static readonly Vector3 SimeonDeliveryMarkerLocation =
            new Vector3(-31.50f, -1090.00f, 26.42f);

        // =========================
        // BLIP SPRITES
        // =========================

        // Car mission blip
        public const int TargetVehicleBlipSprite =
            225;

        // Motorcycle mission blip
        public const int TargetBikeBlipSprite =
            348;

        // Simeon's dealership blip
        public const int DealershipBlipSprite =
            326;

        // =========================
        // BLIP COLORS
        // =========================

        public const int YellowBlipColor =
            66;

        public const int DealershipBlipColor =
            2;

        // =========================
        // BLIP NAMES
        // =========================

        public const string TargetVehicleBlipName =
            "Vehicle Theft Job";

        public const string TargetBikeBlipName =
            "Motorcycle Theft Job";

        public const string DealershipBlipName =
            "Premium Deluxe Motorsport";

        // =========================
        // NOTIFICATIONS
        // =========================

        public const string VehicleAvailableMessage =
            "A high-value vehicle has been located. Check your map.";

        public const string VehicleStolenMessage =
            "The vehicle has been stolen. Lose the cops.";

        public const string CopsLostMessage =
            "The police are gone. Deliver the vehicle to Premium Deluxe Motorsport.";

        public const string MissionFailedVehicleDestroyed =
            "Mission Failed: The vehicle was destroyed.";

        public const string SellPromptFormat =
            "Press ~INPUT_CONTEXT~ to sell the vehicle for ~g~${0:N0}~s~.";
    }
}