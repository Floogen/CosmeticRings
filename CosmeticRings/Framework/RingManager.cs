using CosmeticRings.Framework.Rings;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticRings.Framework
{
    internal enum RingType
    {
        Unknown,
        PetalRing,
        ButterflyRing
    }

    internal static class RingManager
    {
        private static readonly string _ringNamePrefix = "PeacefulEnd.Rings";

        // TODO: Need to reset this on DayStarted, grab player's current rings
        internal static List<RingType> wornRings = new List<RingType>();

        internal static List<string> GetRingNames()
        {
            List<string> ringNames = new List<string>();
            foreach (var ringType in Enum.GetValues(typeof(RingType)))
            {
                ringNames.Add(String.Concat(_ringNamePrefix, ".", ringType));
            }

            return ringNames;
        }

        internal static bool IsCosmeticRing(string ringName)
        {
            return GetRingNames().Contains(ringName);
        }

        internal static bool HasCosmeticRingEquipped(Farmer who)
        {
            return wornRings.Any();
        }

        internal static void UpdateRingEffects(Farmer who, GameLocation location)
        {
            foreach (RingType ringType in wornRings)
            {
                switch (ringType)
                {
                    case RingType.PetalRing:
                        PetalRing.Update(who, location);
                        break;
                    case RingType.ButterflyRing:
                        ButterflyRing.Update(who, location);
                        break;
                    default:
                        // Do nothing, though we should never reach here as Unknown isn't handled
                        break;
                }
            }
        }

        internal static void HandleEquip(Farmer who, GameLocation location, string ringName)
        {
            switch (GetRingTypeFromName(ringName))
            {
                case RingType.PetalRing:
                    wornRings.Add(RingType.PetalRing);
                    PetalRing.HandleEquip(who, location);
                    break;
                case RingType.ButterflyRing:
                    wornRings.Add(RingType.ButterflyRing);
                    ButterflyRing.HandleEquip(who, location);
                    break;
                default:
                    // Do nothing, though we should never reach here as Unknown isn't handled
                    break;
            }
        }

        internal static void HandleUnequip(Farmer who, GameLocation location, string ringName)
        {
            switch (GetRingTypeFromName(ringName))
            {
                case RingType.PetalRing:
                    wornRings.Remove(RingType.PetalRing);
                    PetalRing.HandleUnequip(who, location);
                    break;
                case RingType.ButterflyRing:
                    wornRings.Remove(RingType.ButterflyRing);
                    ButterflyRing.HandleUnequip(who, location);
                    break;
                default:
                    // Do nothing, though we should never reach here as Unknown isn't handled
                    break;
            }
        }

        internal static void HandleNewLocation(Farmer who, GameLocation location, string ringName)
        {
            switch (GetRingTypeFromName(ringName))
            {
                case RingType.PetalRing:
                    wornRings.Remove(RingType.PetalRing);
                    PetalRing.HandleEquip(who, location);
                    break;
                case RingType.ButterflyRing:
                    wornRings.Remove(RingType.ButterflyRing);
                    ButterflyRing.HandleEquip(who, location);
                    break;
                default:
                    // Do nothing, though we should never reach here as Unknown isn't handled
                    break;
            }
        }

        private static RingType GetRingTypeFromName(string ringName)
        {
            switch (ringName.Replace(String.Concat(_ringNamePrefix, "."), ""))
            {
                case nameof(RingType.PetalRing):
                    return RingType.PetalRing;
                case nameof(RingType.ButterflyRing):
                    return RingType.ButterflyRing;
                default:
                    return RingType.Unknown;
            }
        }
    }
}
