﻿using CosmeticRings.Framework.Critters;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticRings.Framework.Rings
{
    internal static class RaindropRing
    {
        private static RainCloud _rainCloud;

        internal static void HandleEquip(Farmer who, GameLocation location)
        {
            // Ensure we can force a critter to appear
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            // Spawn cloud
            _rainCloud = new RainCloud(who.getTileLocation(), 0, (float)Game1.random.Next(15) / 500f, (float)Game1.random.Next(-10, 0) / 50f, (float)Game1.random.Next(10) / 50f);

            location.critters.Add(_rainCloud);
        }

        internal static void HandleUnequip(Farmer who, GameLocation location)
        {
            if (_rainCloud != null)
            {
                location.critters.Remove(_rainCloud);
                _rainCloud = null;
            }
        }

        internal static void HandleNewLocation(Farmer who, GameLocation location)
        {
            // Ensure we can force a critter to appear
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            // Spawn cloud
            _rainCloud = new RainCloud(who.getTileLocation(), 0, (float)Game1.random.Next(15) / 500f, (float)Game1.random.Next(-10, 0) / 50f, (float)Game1.random.Next(10) / 50f);

            location.critters.Add(_rainCloud);
        }

        internal static void HandleLeaveLocation(Farmer who, GameLocation location)
        {

        }

        internal static void Update(Farmer who, GameLocation location)
        {

        }
    }
}