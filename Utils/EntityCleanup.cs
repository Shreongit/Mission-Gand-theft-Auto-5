using HotWheelsVehicleTheftJobs.Core;
using HotWheelsVehicleTheftJobs.UI;

namespace HotWheelsVehicleTheftJobs.Utils
{
    public static class EntityCleanup
    {
        public static void CleanupMission(Mission mission)
        {
            if (mission == null)
                return;

                    
            BlipHelper.Remove(mission.TargetVehicleBlip);
            BlipHelper.Remove(mission.DealershipBlip);

            mission.TargetVehicleBlip = null;
            mission.DealershipBlip = null;

            if (mission.TargetVehicle != null &&
                mission.TargetVehicle.Exists())
            {
                mission.TargetVehicle.IsPersistent = false;
                mission.TargetVehicle.Delete();
            }

            mission.TargetVehicle = null;
        }
    }
    

}