using GTA;

namespace HotWheelsVehicleTheftJobs.UI
{
    public static class NotificationHelper
    {
        public static void Show(string message)
        {
            GTA.UI.Notification.PostTicker(
                message,
                false,
                false
            );
        }

        
        public static void ShowHelpText(string message)
        {
            GTA.UI.Screen.ShowHelpTextThisFrame(message);
        }
    }
    

}