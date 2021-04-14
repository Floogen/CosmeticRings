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
    internal static class BunnyRing
    {
        private static BunnyFollower _bunny;

        internal static void HandleEquip(Farmer who, GameLocation location)
        {
            // Ensure we can force a character to appear
            if (location.characters is null)
            {
                return;
            }

            // Spawn rabbit
            _bunny = new BunnyFollower(who.getTileLocation());

            location.characters.Add(_bunny);
        }

        internal static void HandleUnequip(Farmer who, GameLocation location)
        {
            if (_bunny != null)
            {
                location.characters.Remove(_bunny);
                _bunny = null;
            }
        }

        internal static void HandleNewLocation(Farmer who, GameLocation location)
        {
            // Ensure we can force a character to appear
            if (location.characters is null)
            {
                return;
            }

            // Spawn rabbit
            _bunny = new BunnyFollower(who.getTileLocation());

            location.characters.Add(_bunny);
        }

        internal static void HandleLeaveLocation(Farmer who, GameLocation location)
        {
            if (_bunny != null)
            {
                location.characters.Remove(_bunny);
                _bunny = null;
            }
        }

        internal static void Update(Farmer who, GameLocation location)
        {

        }
    }
}
