using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticRings.Framework
{
    internal static class ResourceManager
    {
        internal static string assetFolderPath;
        internal static string raindropsTexturePath;

        internal static void SetUpAssets(IModHelper helper)
        {
            assetFolderPath = helper.Content.GetActualAssetKey("assets", ContentSource.ModFolder);
            raindropsTexturePath = Path.Combine(assetFolderPath, "Sprites", "Raindrops.png");
        }
    }
}
