using GTA;

namespace HotWheelsVehicleTheftJobs.Systems
{
    public class PoliceSystem
    {
        public void StartWantedLevel(int wantedLevel)
        {
            Game.Player.Wanted.SetWantedLevel(
                wantedLevel,
                false
            );

            Game.Player.Wanted.ApplyWantedLevelChangeNow(
                false
            );
        }

        public bool HasLostPolice()
        {
            return Game.Player.Wanted.WantedLevel == 0;
        }

        public void ClearWantedLevel()
        {
            Game.Player.Wanted.SetWantedLevel(
                0,
                false
            );

            Game.Player.Wanted.ApplyWantedLevelChangeNow(
                false
            );
        }
    }
}