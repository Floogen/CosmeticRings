using CosmeticRings.Framework.Critters;
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
    internal static class PetalRing
    {
        private static Petal _petal;

        internal static void HandleEquip(Farmer who, GameLocation location)
        {
            // Spawn petals

            // Ensure we can force a critter to appear
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            // Spawn butterfly
            _petal = new Petal(who.getTileLocation(), 0, (float)Game1.random.Next(15) / 500f, (float)Game1.random.Next(-10, 0) / 50f, (float)Game1.random.Next(10) / 50f);

            location.critters.Add(_petal);
        }

        internal static void HandleUnequip(Farmer who, GameLocation location)
        {
            // TODO: Despawn petals

        }

        internal static void HandleNewLocation(Farmer who, GameLocation location)
        {
            // Spawn petals
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            // Spawn butterfly
            _petal = new Petal(who.getTileLocation(), 0, (float)Game1.random.Next(15) / 500f, (float)Game1.random.Next(-10, 0) / 50f, (float)Game1.random.Next(10) / 50f);

            location.critters.Add(_petal);
        }

        internal static void Update(Farmer who, GameLocation location)
        {
            // Ensure we can force a critter to appear
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            // Spawn butterfly
            _petal = new Petal(who.getTileLocation(), 0, (float)Game1.random.Next(15) / 500f, (float)Game1.random.Next(-10, 0) / 50f, (float)Game1.random.Next(10) / 50f);

            location.critters.Add(_petal);
        }
    }
}
