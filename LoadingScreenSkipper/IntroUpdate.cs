using HarmonyLib;

namespace LoadingScreenSkipper
{
    [HarmonyPatch(typeof(PLIntro), "Update")]
    class IntroUpdate
    {
        static void Prefix(PLIntro __instance, ref float ___LifeTime, ref bool ___LevelLoadRequestMade)
        {
            if (!___LevelLoadRequestMade)
            {
                ___LevelLoadRequestMade = true;
                ___LifeTime = 11f;
                PLGlobal.IntroFinished = true;
                PLLoader.Instance.LoadThis(new PLLoadRequest(PLGlobal.MainMenuLevelID));
            }
        }
    }
}
