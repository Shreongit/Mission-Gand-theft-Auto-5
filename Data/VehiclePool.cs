using System;
using GTA;

namespace HotWheelsVehicleTheftJobs.Data
{
    public static class VehiclePool
    {
        private static readonly Random Random = new Random();

        private static readonly VehicleData[] Vehicles =
        {
            // =========================
            // SPORTS CARS
            // =========================

            new VehicleData(
                VehicleHash.Comet2,
                35000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.Ninef,
                40000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.Feltzer2,
                45000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.Jester,
                50000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.Massacro,
                55000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.Carbonizzare,
                60000,
                TargetVehicleType.Car
            ),

            // =========================
            // SUPER CARS
            // =========================

            new VehicleData(
                VehicleHash.Adder,
                120000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.EntityXF,
                130000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                (VehicleHash)1663218586,
                140000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.Zentorno,
                150000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.Osiris,
                175000,
                TargetVehicleType.Car
            ),

            new VehicleData(
                VehicleHash.T20,
                200000,
                TargetVehicleType.Car
            ),

            // =========================
            // HIGH-VALUE MOTORCYCLES
            // =========================

            new VehicleData(
                VehicleHash.Bati,
                30000,
                TargetVehicleType.Bike
            ),

            new VehicleData(
                VehicleHash.Akuma,
                35000,
                TargetVehicleType.Bike
            ),

            new VehicleData(
                VehicleHash.Double,
                45000,
                TargetVehicleType.Bike
            ),

            new VehicleData(
                VehicleHash.CarbonRS,
                60000,
                TargetVehicleType.Bike
            ),

            new VehicleData(
                VehicleHash.Hakuchou,
                70000,
                TargetVehicleType.Bike
            ),

            new VehicleData(
                VehicleHash.Nemesis,
                80000,
                TargetVehicleType.Bike
            )
        };

        public static VehicleData GetRandomVehicle()
        {
            return Vehicles[
                Random.Next(Vehicles.Length)
            ];
        }
    }

    public enum TargetVehicleType
    {
        Car,
        Bike
    }

    public class VehicleData
    {
        public VehicleHash VehicleHash { get; }

        public int SalePrice { get; }

        public TargetVehicleType VehicleType { get; }

        public VehicleData(
            VehicleHash vehicleHash,
            int salePrice,
            TargetVehicleType vehicleType)
        {
            VehicleHash = vehicleHash;
            SalePrice = salePrice;
            VehicleType = vehicleType;
        }
    }
}