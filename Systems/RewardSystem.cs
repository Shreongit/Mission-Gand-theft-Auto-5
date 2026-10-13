using HotWheelsVehicleTheftJobs.Core;

namespace HotWheelsVehicleTheftJobs.Systems
{
    public class RewardSystem
    {
        public int GetReward(Mission mission)
        {
            if (mission == null)
                return 0;

                    
            return mission.SalePrice;
        }
    }
    

}