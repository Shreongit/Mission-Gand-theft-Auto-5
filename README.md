# Hot Wheels: Vehicle Theft Jobs

A GTA V single-player vehicle theft mission mod featuring high-end cars, motorcycles, police chases, vehicle deliveries, and high-value military theft missions.

Steal valuable vehicles across Los Santos, escape the police, deliver them safely, and get paid.

---

## Features

- Random vehicle theft missions
- Sports car targets
- Super car targets
- Motorcycle theft missions
- Different map blips for cars and motorcycles
- Multiple mission locations around Los Santos
- Optional missions that can be accepted or ignored
- 3-star wanted level for standard vehicle thefts
- Police must be lost before the vehicle can be delivered
- GPS route to the delivery location after escaping the police
- Vehicle selling system
- Cash rewards for successful deliveries
- 30-second mission cooldown
- Mission progression system
- High-value military theft missions
- Rhino Tank theft from Fort Zancudo
- 5-star wanted level for the military mission
- Delivery to Sandy Shores Airfield
- High-value reward for completing the tank mission

---

# Standard Vehicle Theft Jobs

Vehicle theft opportunities randomly appear around Los Santos.

A yellow target blip will appear on the map, marking the location of a valuable vehicle.

Depending on the mission, the target can be:

- Sports Car
- Super Car
- Motorcycle

The mission is optional.

You can choose to drive to the target and steal it, or ignore the opportunity and continue playing GTA V normally.

Once you enter the target vehicle, the police will be alerted.

You will receive a **3-star wanted level**.

Your objective is to escape the police while keeping the stolen vehicle safe.

Once your wanted level reaches zero, a GPS route will appear and guide you to **Premium Deluxe Motorsport**.

Drive the stolen vehicle into the designated delivery area.

You will receive a prompt showing the sale price.

Press **E** to sell the vehicle.

The vehicle will be removed from the world and the reward money will be added to the player.

---

## Standard Mission Flow

```text
Find the target
      |
      v
Steal the vehicle
      |
      v
Receive a 3-star wanted level
      |
      v
Lose the police
      |
      v
GPS route appears
      |
      v
Deliver to Premium Deluxe Motorsport
      |
      v
Press E to sell
      |
      v
Get paid
```

---

# High-Value Military Theft Mission

After completing standard vehicle theft jobs, a special high-value mission can appear.

This mission is significantly more dangerous than a normal vehicle theft.

Your target is a **Rhino Tank** located at **Fort Zancudo**.

Travel to the military base and steal the tank.

Once you successfully take control of the Rhino Tank, you will receive a **5-star wanted level**.

You must escape the military base and lose the police and military forces before the delivery location becomes available.

Once your wanted level reaches zero, a GPS route will appear.

Your destination is:

## Sandy Shores Airfield

Drive the stolen Rhino Tank to the designated hangar delivery area.

Press **E** to sell the tank and complete the mission.

Successful completion of the high-value mission rewards:

# $500,000

---

## High-Value Mission Flow

```text
Travel to Fort Zancudo
      |
      v
Locate the Rhino Tank
      |
      v
Steal the Tank
      |
      v
Receive a 5-star wanted level
      |
      v
Escape the military and police
      |
      v
Lose your wanted level
      |
      v
GPS route to Sandy Shores appears
      |
      v
Deliver the Tank to the Airfield Hangar
      |
      v
Press E to sell
      |
      v
Receive $500,000
```

---

# Mission Progression

The mod follows a repeating mission cycle.

```text
MISSION 1
Random Car or Motorcycle Theft
3-Star Wanted Level
Premium Deluxe Motorsport Delivery

        |
        v

MISSION 2
Random Car or Motorcycle Theft
3-Star Wanted Level
Premium Deluxe Motorsport Delivery

        |
        v

MISSION 3
HIGH-VALUE MILITARY THEFT

Steal a Rhino Tank
Fort Zancudo

5-Star Wanted Level

Deliver to Sandy Shores Airfield

Reward: $500,000

        |
        v

MISSION CYCLE RESTARTS
```

After completing the high-value mission, the cycle returns to standard vehicle theft jobs.

---

# Mission Cooldown

After completing a mission, the next theft opportunity does not appear immediately.

The current mission cooldown is:

```text
30 seconds
```

This gives players a short break between missions while keeping the gameplay active.

---

# Installation

## Requirements

Before installing the mod, make sure you have:

- Script Hook V
- ScriptHookVDotNet

## Installation Steps

1. Install Script Hook V.
2. Install ScriptHookVDotNet.
3. Open your GTA V installation directory.
4. Open the `scripts` folder.
5. Copy `HotWheelsVehicleTheftJobs.dll` into the `scripts` folder.
6. Start GTA V in Story Mode.

Your installation should look similar to this:

```text
Grand Theft Auto V/
|
|-- GTA5.exe
|
|-- ScriptHookV.dll
|
|-- scripts/
    |
    |-- HotWheelsVehicleTheftJobs.dll
```

---

# Building From Source

## Requirements

To build the project from source, you need:

- .NET SDK with .NET Framework 4.8 targeting support
- GTA V
- Script Hook V
- ScriptHookVDotNet

Clone the repository:

```bash
git clone https://github.com/YOUR_USERNAME/HotWheelsVehicleTheftJobs.git
```

Open the project directory:

```bash
cd HotWheelsVehicleTheftJobs
```

Build the project:

```bash
dotnet build
```

The compiled DLL will be generated in:

```text
bin/Debug/net48/HotWheelsVehicleTheftJobs.dll
```

Copy the generated DLL into:

```text
Grand Theft Auto V/scripts/
```

---

# Project Structure

```text
HotWheelsVehicleTheftJobs/
|
|-- Config/
|   |-- MissionConfig.cs
|
|-- Core/
|   |-- Mission.cs
|   |-- MissionManager.cs
|   |-- MissionState.cs
|   |-- MissionType.cs
|
|-- Data/
|   |-- HighValueMissionData.cs
|   |-- MissionLocations.cs
|   |-- TargetVehicleType.cs
|   |-- VehicleData.cs
|   |-- VehiclePool.cs
|
|-- Systems/
|   |-- DeliverySystem.cs
|   |-- HighValueMissionSpawner.cs
|   |-- MissionScheduler.cs
|   |-- PoliceSystem.cs
|   |-- RewardSystem.cs
|   |-- VehicleMissionSpawner.cs
|
|-- UI/
|   |-- BlipHelper.cs
|   |-- MarkerHelper.cs
|   |-- NotificationHelper.cs
|
|-- Utils/
|   |-- EntityCleanup.cs
|
|-- Main.cs
|
|-- README.md
|
|-- CHANGELOG.md
|
|-- LICENSE
```

---

# Gameplay

The main gameplay loop is simple:

```text
Find a target
        |
        v
Steal the vehicle
        |
        v
Escape the police
        |
        v
Deliver the vehicle
        |
        v
Sell it
        |
        v
Get paid
        |
        v
Wait for the next job
```

Every mission can feel different depending on:

- The vehicle selected
- Whether the target is a car or motorcycle
- The mission spawn location
- The police chase
- The reward
- The difficulty of reaching the delivery location

The high-value military mission provides an additional challenge by introducing a Rhino Tank, Fort Zancudo, a 5-star wanted level, and a long-distance delivery to Sandy Shores.

---

# Important

Keep the stolen target vehicle safe.

If the mission vehicle is destroyed or lost, the mission may fail and you will not receive the reward.

The high-value military mission is especially dangerous.

Stealing the Rhino Tank is only the beginning.

You must:

1. Enter Fort Zancudo.
2. Locate the Rhino Tank.
3. Steal the tank.
4. Survive the 5-star wanted level.
5. Escape the military base.
6. Lose the authorities.
7. Drive to Sandy Shores.
8. Deliver the tank successfully.

---

# Known Issues

No known major issues at the time of release.

If you encounter:

- A bug
- An unexpected vehicle spawn
- A mission that does not progress
- A vehicle spawning in an incorrect location
- A delivery problem
- A compatibility issue

Please report it in the **GitHub Issues** section.

When reporting an issue, include as much information as possible:

- What happened
- Which mission you were playing
- What vehicle was involved
- Where the issue occurred
- Any error message you received
- Screenshots or videos, if available

This will help identify and fix the problem more easily.

---

# Feedback and Suggestions

Feedback is always welcome.

If you have ideas for future updates, feel free to open an issue or start a discussion.

Suggestions are welcome for:

- New vehicle types
- New theft missions
- New high-value missions
- New locations
- New delivery locations
- Different police mechanics
- New rewards
- Difficulty settings
- Random mission events
- Additional vehicle categories
- New gameplay features

Community feedback can help shape future versions of **Hot Wheels: Vehicle Theft Jobs**.

---

# Contributing

Contributions are welcome.

If you want to contribute:

1. Fork the repository.
2. Create a new branch.
3. Make your changes.
4. Test the mod.
5. Submit a pull request.

Please make sure your changes are tested before submitting a pull request.

---

# Credits

Created and developed by **Shreynmods**.

Special thanks to:

- The GTA V modding community
- Script Hook V
- ScriptHookVDotNet

---

# License

Please see the `LICENSE` file for licensing information.

---

## Hot Wheels: Vehicle Theft Jobs

**Steal the vehicle.**

**Escape the heat.**

**Deliver the job.**

**Get paid.**
