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
    internal static class ButterflyRing
    {
        private static ButterflyFollower _butterfly;

        internal static void HandleEquip(Farmer who, GameLocation location)
        {
            // Ensure we can force a critter to appear
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }

            // Spawn butterfly
            _butterfly = new ButterflyFollower(who.getTileLocation());
            location.critters.Add(_butterfly);
        }

        internal static void HandleUnequip(Farmer who, GameLocation location)
        {
            if (_butterfly != null)
            {
                location.critters.Remove(_butterfly);
            }
        }

        internal static void Update(Farmer who, GameLocation location)
        {

        }
    }
}
