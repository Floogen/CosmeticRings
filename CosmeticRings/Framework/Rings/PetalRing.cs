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
        internal static void HandleEquip(Farmer who, GameLocation location)
        {
            // Spawn petals
            CosmeticRings.monitor.Log("HERE", StardewModdingAPI.LogLevel.Debug);
        }

        internal static void HandleUnequip(Farmer who, GameLocation location)
        {
            // TODO: Despawn petals

        }

        internal static void Update(Farmer who, GameLocation location)
        {
            if (location.critters is null)
            {
                location.critters = new List<Critter>();
            }
            location.critters.Add(new Butterfly(who.getTileLocation()));
        }
    }
}
