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
    internal static class FairyRing
    {
        private static Fairy _fairy;

        internal static void HandleEquip(Farmer who, GameLocation location)
        {
            // Ensure we can force a critter to appear
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            // Spawn butterfly
            _fairy = new Fairy(who.getTileLocation());

            location.critters.Add(_fairy);
        }

        internal static void HandleUnequip(Farmer who, GameLocation location)
        {
            if (_fairy != null)
            {
                location.critters.Remove(_fairy);
                _fairy = null;
            }
        }

        internal static void HandleNewLocation(Farmer who, GameLocation location)
        {
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            if (_fairy is null)
            {
                // Spawn butterfly
                _fairy = new Fairy(who.getTileLocation());
            }

            _fairy.resetForNewLocation(who.getTileLocation());
            location.critters.Add(_fairy);
        }

        internal static void Update(Farmer who, GameLocation location)
        {
            // Do nothing
        }
    }
}
