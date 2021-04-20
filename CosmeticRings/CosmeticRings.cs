using CosmeticRings.Framework;
using CosmeticRings.Framework.Interfaces;
using CosmeticRings.Framework.Patches;
using Harmony;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Objects;
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

        private IWearMoreRingsApi wearMoreRingsApi;

        public override void Entry(IModHelper helper)
        {
            // Set up the monitor and helper
            monitor = Monitor;
            modHelper = helper;

            // Set up our resource manager
            ResourceManager.SetUpAssets(helper);

            // Load our Harmony patches
            try
            {
                var harmony = HarmonyInstance.Create(this.ModManifest.UniqueID);

                // Apply our patches
                new RingPatch(monitor).Apply(harmony);
                new UtilityPatch(monitor).Apply(harmony);
            }
            catch (Exception e)
            {
                Monitor.Log($"Issue with Harmony patching: {e}", LogLevel.Error);
                return;
            }

            // Hook into GameLoop events
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
            helper.Events.GameLoop.Saving += this.OnSaving;
            helper.Events.GameLoop.OneSecondUpdateTicked += this.OnOneSecondUpdateTicked;
        }

        private void OnSaving(object sender, SavingEventArgs e)
        {
            // Go through all game locations and purge any of custom critters / creatures
            foreach (GameLocation location in Game1.locations.Where(l => l != null))
            {
                if (location.critters != null)
                {
                    foreach (var critter in location.critters.Where(c => IsCustomFollower(c)).ToList())
                    {
                        location.critters.Remove(critter);
                    }
                }

                if (location.characters != null)
                {
                    foreach (var creature in location.characters.Where(c => IsCustomFollower(c)).ToList())
                    {
                        location.characters.Remove(creature);
                    }
                }
            }
        }

        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            if (wearMoreRingsApi != null)
            {
                RingManager.LoadWornRings(Game1.player, Game1.currentLocation, wearMoreRingsApi.GetAllRings(Game1.player));
            }
            else
            {
                RingManager.LoadWornRings(Game1.player, Game1.currentLocation, new List<Ring>() { Game1.player.leftRing, Game1.player.rightRing });
            }
        }

        private void OnOneSecondUpdateTicked(object sender, OneSecondUpdateTickedEventArgs e)
        {
            if (RingManager.HasCosmeticRingEquipped(Game1.player))
            {
                RingManager.UpdateRingEffects(Game1.player, Game1.currentLocation);
            }
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            // Hook into the APIs we utilize
            if (Helper.ModRegistry.IsLoaded("spacechase0.JsonAssets") && ApiManager.HookIntoJsonAssets(Helper))
            {
                // Load in our ring assets
                var jsonAssetsApi = ApiManager.GetJsonAssetsApi();
                jsonAssetsApi.LoadAssets(Path.Combine(Helper.DirectoryPath, "assets", "[JA] Cosmetic Rings Pack"));
            }

            if (Helper.ModRegistry.IsLoaded("bcmpinc.WearMoreRings") && ApiManager.HookIntoIWMR(Helper))
            {
                wearMoreRingsApi = ApiManager.GetIWMRApi();
            }
        }

        internal static bool IsCustomFollower(object follower)
        {
            if (follower != null && follower.GetType().Namespace == "CosmeticRings.Framework.Critters")
            {
                return true;
            }

            return false;
        }
    }
}