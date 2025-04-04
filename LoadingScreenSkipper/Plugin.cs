using BepInEx;
using HarmonyLib;

namespace LoadingScreenSkipper
{
    [BepInPlugin("com.18107.cutsceneskipper", "Cutscene Skipper", "0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Cutscene Skipper loaded!");
            var harmony = new Harmony("com.18107.cutsceneskipper");
            harmony.PatchAll();
            Logger.LogInfo("Harmony patches applied!");
            foreach (var method in harmony.GetPatchedMethods())
            {
                Logger.LogInfo($"Patched method: {method.DeclaringType.Name}.{method.Name}");
            }
        }
    }
}
