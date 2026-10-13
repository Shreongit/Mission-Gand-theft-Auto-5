using GTA;
using GTA.Math;
using HotWheelsVehicleTheftJobs.Data;

namespace HotWheelsVehicleTheftJobs.Core
{
    public class Mission
    {
        public Vehicle TargetVehicle { get; set; }

        public Blip TargetVehicleBlip { get; set; }

        public Blip DealershipBlip { get; set; }

        public Vector3 VehicleSpawnLocation { get; set; }

        public Vector3 DeliveryLocation { get; set; }

        public int SalePrice { get; set; }

        public TargetVehicleType VehicleType { get; set; }

        // Mission category
        public MissionType MissionType { get; set; }

        // Wanted level for this specific mission
        public int WantedLevel { get; set; }

        public MissionState State { get; set; }

        public bool TheftStarted { get; set; }

        public bool PoliceLost { get; set; }

        // True for the Fort Zancudo military mission
        public bool IsHighValueMission
        {
            get
            {
                return MissionType ==
                       MissionType.HighValueMilitaryTheft;
            }
        }
    }
}