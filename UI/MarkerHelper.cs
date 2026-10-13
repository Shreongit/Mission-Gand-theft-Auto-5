using System.Drawing;
using GTA;
using GTA.Math;

namespace HotWheelsVehicleTheftJobs.UI
{
    public static class MarkerHelper
    {
        public static void DrawDeliveryMarker(Vector3 position)
        {
            World.DrawMarker(
                MarkerType.Cylinder,
                position,
                Vector3.Zero,
                Vector3.Zero,
                new Vector3(3.0f, 3.0f, 1.0f),
                Color.FromArgb(180, 255, 215, 0)
            );
        }
    }
}