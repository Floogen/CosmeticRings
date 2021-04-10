﻿using Harmony;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticRings.Framework.Patches
{
    internal class RingPatch
    {
        private static IMonitor monitor;
        private readonly Type _ring = typeof(Ring);

        internal RingPatch(IMonitor modMonitor)
        {
            monitor = modMonitor;
        }

        internal void Apply(HarmonyInstance harmony)
        {
            harmony.Patch(AccessTools.Method(_ring, nameof(Ring.onEquip), new[] { typeof(Farmer), typeof(GameLocation) }), postfix: new HarmonyMethod(GetType(), nameof(OnEquipPostfix)));
            harmony.Patch(AccessTools.Method(_ring, nameof(Ring.onUnequip), new[] { typeof(Farmer), typeof(GameLocation) }), postfix: new HarmonyMethod(GetType(), nameof(OnUnequipPostfix)));
        }

        private static void OnEquipPostfix(Ring __instance)
        {
            if (RingManager.IsCosmeticRing(__instance.Name))
            {
                monitor.Log("PING", LogLevel.Debug);
            }
        }

        private static void OnUnequipPostfix(Ring __instance)
        {
            if (RingManager.IsCosmeticRing(__instance.Name))
            {
                monitor.Log("PONG", LogLevel.Debug);
            }
        }
    }
}