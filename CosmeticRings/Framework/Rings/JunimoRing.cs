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
    internal static class JunimoRing
    {
        private static JunimoFollower _junimoFollower;

        internal static void HandleEquip(Farmer who, GameLocation location)
        {
            // Ensure we can force a character to appear
            if (location.characters is null)
            {
                return;
            }

            // Spawn Junimo
            _junimoFollower = new JunimoFollower(who.getTileLocation());

            location.characters.Add(_junimoFollower);
        }

        internal static void HandleUnequip(Farmer who, GameLocation location)
        {
            if (_junimoFollower != null)
            {
                location.characters.Remove(_junimoFollower);
                _junimoFollower = null;
            }
        }

        internal static void HandleNewLocation(Farmer who, GameLocation location)
        {
            // Ensure we can force a character to appear
            if (location.characters is null)
            {
                return;
            }

            // Spawn Junimo
            if (_junimoFollower is null)
            {
                _junimoFollower = new JunimoFollower(who.getTileLocation());
            }

            _junimoFollower.resetForNewLocation(who.getTileLocation());
            location.characters.Add(_junimoFollower);
        }

        internal static void HandleLeaveLocation(Farmer who, GameLocation location)
        {
            if (_junimoFollower != null)
            {
                location.characters.Remove(_junimoFollower);
            }
        }

        internal static void Update(Farmer who, GameLocation location)
        {

        }
    }
}
