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
        ButterflyRing,
        FairyRing,
        RaindropRing,
        BunnyRing,
        JunimoRing
    }

    internal static class RingManager
    {
        private static readonly string _ringNamePrefix = "PeacefulEnd.Rings";
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
                    case RingType.FairyRing:
                        FairyRing.Update(who, location);
                        break;
                    case RingType.RaindropRing:
                        RaindropRing.Update(who, location);
                        break;
                    case RingType.BunnyRing:
                        BunnyRing.Update(who, location);
                        break;
                    case RingType.JunimoRing:
                        JunimoRing.Update(who, location);
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
                case RingType.FairyRing:
                    wornRings.Add(RingType.FairyRing);
                    FairyRing.HandleEquip(who, location);
                    break;
                case RingType.RaindropRing:
                    wornRings.Add(RingType.RaindropRing);
                    RaindropRing.HandleEquip(who, location);
                    break;
                case RingType.BunnyRing:
                    wornRings.Add(RingType.BunnyRing);
                    BunnyRing.HandleEquip(who, location);
                    break;
                case RingType.JunimoRing:
                    wornRings.Add(RingType.JunimoRing);
                    JunimoRing.HandleEquip(who, location);
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
                case RingType.FairyRing:
                    wornRings.Remove(RingType.FairyRing);
                    FairyRing.HandleUnequip(who, location);
                    break;
                case RingType.RaindropRing:
                    wornRings.Remove(RingType.RaindropRing);
                    RaindropRing.HandleUnequip(who, location);
                    break;
                case RingType.BunnyRing:
                    wornRings.Remove(RingType.BunnyRing);
                    BunnyRing.HandleUnequip(who, location);
                    break;
                case RingType.JunimoRing:
                    wornRings.Remove(RingType.JunimoRing);
                    JunimoRing.HandleUnequip(who, location);
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
                    PetalRing.HandleNewLocation(who, location);
                    break;
                case RingType.ButterflyRing:
                    ButterflyRing.HandleNewLocation(who, location);
                    break;
                case RingType.FairyRing:
                    FairyRing.HandleNewLocation(who, location);
                    break;
                case RingType.RaindropRing:
                    RaindropRing.HandleNewLocation(who, location);
                    break;
                case RingType.BunnyRing:
                    BunnyRing.HandleNewLocation(who, location);
                    break;
                case RingType.JunimoRing:
                    JunimoRing.HandleNewLocation(who, location);
                    break;
                default:
                    // Do nothing, though we should never reach here as Unknown isn't handled
                    break;
            }
        }

        internal static void HandleLeaveLocation(Farmer who, GameLocation location, string ringName)
        {
            switch (GetRingTypeFromName(ringName))
            {
                case RingType.PetalRing:
                    PetalRing.HandleLeaveLocation(who, location);
                    break;
                case RingType.ButterflyRing:
                    ButterflyRing.HandleLeaveLocation(who, location);
                    break;
                case RingType.FairyRing:
                    FairyRing.HandleLeaveLocation(who, location);
                    break;
                case RingType.RaindropRing:
                    RaindropRing.HandleLeaveLocation(who, location);
                    break;
                case RingType.BunnyRing:
                    BunnyRing.HandleLeaveLocation(who, location);
                    break;
                case RingType.JunimoRing:
                    JunimoRing.HandleLeaveLocation(who, location);
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
                case nameof(RingType.FairyRing):
                    return RingType.FairyRing;
                case nameof(RingType.RaindropRing):
                    return RingType.RaindropRing;
                case nameof(RingType.BunnyRing):
                    return RingType.BunnyRing;
                case nameof(RingType.JunimoRing):
                    return RingType.JunimoRing;
                default:
                    return RingType.Unknown;
            }
        }
    }
}
