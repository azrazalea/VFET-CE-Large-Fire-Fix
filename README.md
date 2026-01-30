# VFET + Combat Extended Large Fire Fix

A compatibility patch that fixes an issue where the Large Fire from **Vanilla Factions Expanded - Tribals** constantly sets pawns on fire when **Combat Extended** is installed.

## The Problem

1. VFET's Large Fire spawns visual sparks every ~0.5 seconds within a 2.9 cell radius
2. These sparks use RimWorld's vanilla `Spark` class which calls `FireUtility.TryStartFireIn()` on impact
3. Combat Extended patches this method to add a 50% chance (modified by Flammability stat) for pawns at that location to catch fire
4. Result: Pawns near a Large Fire are constantly igniting

## The Fix

This mod replaces VFET's spark projectile with a visual-only version (`Spark_Visual`) that doesn't attempt to start fires when it lands. Campfire sparks are purely decorative and shouldn't be setting pawns ablaze anyway.

## Requirements

- Vanilla Factions Expanded - Tribals
- Combat Extended

## Installation

1. Subscribe on Steam Workshop, or download and place in your RimWorld/Mods folder
2. Enable in mod list
3. Load after both VFET and Combat Extended

## Technical Details

- `Spark_Visual` class inherits from vanilla `Spark` (required for VFET's code cast)
- Overrides `Impact()` to simply destroy the projectile without calling fire-starting logic
- XML patch changes `VFET_LargeFireSpark` thingClass to use our visual-only version

## Building from Source

```bash
cd Source
dotnet build VFET-CE-LargeFireFix.csproj
```

## License

MIT
