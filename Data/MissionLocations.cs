using System;
using GTA.Math;

namespace HotWheelsVehicleTheftJobs.Data
{
    public static class MissionLocations
    {
        private static readonly Random Random = new Random();

        private static readonly Vector3[] Locations =
        {
            // =========================
            // ROCKFORD HILLS
            // =========================

            new Vector3(-857.65f, -149.43f, 37.75f),
            new Vector3(-723.88f, -115.45f, 37.32f),
            new Vector3(-667.89f, -264.72f, 35.94f),
            new Vector3(-845.36f, -651.92f, 27.71f),
            new Vector3(-949.48f, -492.32f, 36.01f),

            // =========================
            // VINEWOOD
            // =========================

            new Vector3(311.65f, 180.34f, 103.64f),
            new Vector3(407.17f, 258.12f, 102.02f),
            new Vector3(338.84f, 155.76f, 103.18f),
            new Vector3(190.24f, 304.71f, 105.39f),
            new Vector3(-15.82f, 257.14f, 109.55f),
            new Vector3(-420.57f, 294.91f, 83.23f),

            // =========================
            // DOWNTOWN LOS SANTOS
            // =========================

            new Vector3(215.32f, -860.45f, 30.15f),
            new Vector3(274.81f, -595.93f, 43.28f),
            new Vector3(142.72f, -1025.41f, 29.34f),
            new Vector3(303.66f, -1074.81f, 29.40f),
            new Vector3(-83.54f, -819.62f, 44.24f),

            // =========================
            // DEL PERRO
            // =========================

            new Vector3(-1388.65f, -586.42f, 30.22f),
            new Vector3(-1464.73f, -382.91f, 38.58f),
            new Vector3(-1238.48f, -870.36f, 12.94f),
            new Vector3(-1581.91f, -530.64f, 34.95f),
            new Vector3(-1323.67f, -929.24f, 12.36f),

            // =========================
            // VESPUCCI
            // =========================

            new Vector3(-1167.38f, -1515.62f, 4.37f),
            new Vector3(-1088.56f, -1263.44f, 5.97f),
            new Vector3(-1285.71f, -1135.64f, 6.84f),
            new Vector3(-1017.36f, -1523.72f, 5.15f),
            new Vector3(-1126.48f, -1702.71f, 4.43f),

            // =========================
            // LA MESA
            // =========================

            new Vector3(742.17f, -1038.64f, 22.16f),
            new Vector3(931.24f, -1487.35f, 30.17f),
            new Vector3(805.42f, -1967.83f, 29.28f),
            new Vector3(1051.76f, -782.31f, 58.26f),
            new Vector3(814.58f, -723.41f, 26.18f),

            // =========================
            // LITTLE SEOUL
            // =========================

            new Vector3(-699.54f, -938.26f, 19.01f),
            new Vector3(-778.42f, -1042.71f, 12.98f),
            new Vector3(-638.17f, -874.63f, 24.46f),

            // =========================
            // MIRROR PARK
            // =========================

            new Vector3(1125.46f, -497.28f, 64.08f),
            new Vector3(1218.54f, -466.82f, 66.21f),
            new Vector3(1077.26f, -616.53f, 58.82f),

            // =========================
            // MISSION ROW
            // =========================

            new Vector3(409.72f, -993.41f, 29.42f),
            new Vector3(448.86f, -1077.23f, 29.21f),
            new Vector3(526.43f, -1208.75f, 29.29f)
        };

        public static Vector3 GetRandomLocation()
        {
            return Locations[
                Random.Next(Locations.Length)
            ];
        }
    }
}