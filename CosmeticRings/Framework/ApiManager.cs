using StardewModdingAPI;
using CosmeticRings.Framework.Interfaces;

namespace CosmeticRings.Framework
{
    public static class ApiManager
    {
        private static IMonitor monitor = CosmeticRings.monitor;
        private static IJsonAssetsApi jsonAssetsApi;

        public static bool HookIntoJsonAssets(IModHelper helper)
        {
            jsonAssetsApi = helper.ModRegistry.GetApi<IJsonAssetsApi>("spacechase0.JsonAssets");

            if (jsonAssetsApi is null)
            {
                monitor.Log("Failed to hook into spacechase0.JsonAssets.", LogLevel.Error);
                return false;
            }

            monitor.Log("Successfully hooked into spacechase0.JsonAssets.", LogLevel.Debug);
            return true;
        }

        public static IJsonAssetsApi GetJsonAssetsApi()
        {
            return jsonAssetsApi;
        }
    }
}
