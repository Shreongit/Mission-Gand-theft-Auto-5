using HotWheelsVehicleTheftJobs.Core;

namespace HotWheelsVehicleTheftJobs.Systems
{
    public class MissionScheduler
    {
        private int _completedStandardMissions;

        public bool ShouldStartHighValueMission()
        {
            return _completedStandardMissions >= 2;
        }

        public void RegisterMissionCompleted(Mission mission)
        {
            if (mission == null)
                return;

            if (mission.MissionType ==
                MissionType.HighValueMilitaryTheft)
            {
                // Reset the cycle after the tank mission
                _completedStandardMissions = 0;
                return;
            }

            if (mission.MissionType ==
                MissionType.StandardVehicleTheft)
            {
                _completedStandardMissions++;
            }
        }

        public void Reset()
        {
            _completedStandardMissions = 0;
        }
    }
}