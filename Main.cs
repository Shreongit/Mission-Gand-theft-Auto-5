using System;
using System.Windows.Forms;
using GTA;
using HotWheelsVehicleTheftJobs.Core;

namespace HotWheelsVehicleTheftJobs
{
    public class Main : Script
    {
        private readonly MissionManager _missionManager;

        
        public Main()
        {
            _missionManager = new MissionManager();

            Tick += OnTick;
            KeyDown += OnKeyDown;

            Aborted += OnAborted;

            Interval = 0;
        }

        private void OnTick(object sender, EventArgs e)
        {
            _missionManager.Update();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            _missionManager.HandleKeyPress(e.KeyCode);
        }

        private void OnAborted(object sender, EventArgs e)
        {
            _missionManager.Dispose();
        }
    }
    

}