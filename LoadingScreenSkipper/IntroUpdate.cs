using HarmonyLib;
using UnityEngine;

namespace LoadingScreenSkipper
{
    [HarmonyPatch(typeof(PLIntro), "Update")]
    class IntroUpdate
    {
        static bool firstRun = true;

        static bool Prefix(
            PLIntro __instance,
            ref float ___LifeTime,
            ref bool ___LevelLoadRequestMade
        )
        {
            if (firstRun && !___LevelLoadRequestMade)
            {
                Debug.Log("Cutscene Skipper: Skipping splash and intro via PLIntro.Update");
                firstRun = false;
                ___LifeTime = 11f;
                ___LevelLoadRequestMade = true;
                PLGlobal.IntroFinished = true;
                __instance.StartCoroutine(DelayedLoad());
                return false;
            }
            return true;
        }

        static System.Collections.IEnumerator DelayedLoad()
        {
            yield return new WaitForSeconds(0.1f);
            PLLoader.Instance.LoadThis(new PLLoadRequest(PLGlobal.MainMenuLevelID));
            Debug.Log("Cutscene Skipper: Main menu loaded after delay");
        }
    }
}
