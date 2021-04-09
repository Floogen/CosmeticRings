using CosmeticRings.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticRings
{
    public class CosmeticRings : Mod
    {
        internal static IMonitor monitor;
        internal static IModHelper modHelper;

        public override void Entry(IModHelper helper)
        {
            // Set up the monitor and helper
            monitor = Monitor;
            modHelper = helper;

            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            // Hook into the APIs we utilize
            if (Helper.ModRegistry.IsLoaded("spacechase0.JsonAssets") && ApiManager.HookIntoJsonAssets(Helper))
            {
                // Load in our ring assets
                var jsonAssetsApi = ApiManager.GetJsonAssetsApi();
                jsonAssetsApi.LoadAssets(Path.Combine(Helper.DirectoryPath, "assets"));
            }
        }
    }
}