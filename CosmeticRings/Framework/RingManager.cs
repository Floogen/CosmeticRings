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
        PetalRing
    }

    internal static class RingManager
    {
        private static readonly string _ringNamePrefix = "PeacefulEnd.Rings";

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

        internal static void HandleEquip(RingType ring)
    }
}
