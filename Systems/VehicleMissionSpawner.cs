using GTA;
using GTA.Math;
using HotWheelsVehicleTheftJobs.Config;
using HotWheelsVehicleTheftJobs.Core;
using HotWheelsVehicleTheftJobs.Data;
using HotWheelsVehicleTheftJobs.UI;

namespace HotWheelsVehicleTheftJobs.Systems
{
    public class VehicleMissionSpawner
    {
        public Mission CreateMission()
        {
            VehicleData vehicleData =
                VehiclePool.GetRandomVehicle();

            Vector3 spawnLocation =
                MissionLocations.GetRandomLocation();

            Model vehicleModel =
                new Model(vehicleData.VehicleHash);

            if (!vehicleModel.IsInCdImage ||
                !vehicleModel.IsVehicle)
            {
                return null;
            }

            vehicleModel.Request(5000);

            if (!vehicleModel.IsLoaded)
                return null;

            // Spawn slightly above the location first
            Vector3 safeSpawnLocation =
                new Vector3(
                    spawnLocation.X,
                    spawnLocation.Y,
                    spawnLocation.Z + 2.0f
                );

            Vehicle vehicle = Vehicle.Create(
                vehicleModel,
                safeSpawnLocation
            );

            vehicleModel.MarkAsNoLongerNeeded();

            if (vehicle == null || !vehicle.Exists())
                return null;

            vehicle.IsPersistent = true;
            vehicle.IsInvincible = false;
            vehicle.IsUndriveable = false;

            // Let GTA place the vehicle correctly on the ground
            vehicle.PlaceOnGround();

            // Make sure it starts upright
            vehicle.Rotation =
                new Vector3(
                    0.0f,
                    0.0f,
                    vehicle.Rotation.Z
                );

            Blip vehicleBlip =
                BlipHelper.CreateTargetVehicleBlip(
                    vehicle,
                    vehicleData.VehicleType
                );

            Mission mission = new Mission
            {
                TargetVehicle = vehicle,

                TargetVehicleBlip =
                    vehicleBlip,

                VehicleSpawnLocation =
                    spawnLocation,

                DeliveryLocation =
                    MissionConfig.SimeonDeliveryMarkerLocation,

                SalePrice =
                    vehicleData.SalePrice,

                VehicleType =
                    vehicleData.VehicleType,

                MissionType =
                    MissionType.StandardVehicleTheft,

                WantedLevel =
                    MissionConfig.WantedLevel,

                State =
                    MissionState.MissionAvailable,

                TheftStarted = false,

                PoliceLost = false
            };

            return mission;
        }
    }
}