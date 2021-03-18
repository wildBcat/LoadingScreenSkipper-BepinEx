using PulsarPluginLoader;

namespace LoadingScreenSkipper
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.0.0";

        public override string Author => "18107";

        public override string ShortDescription => "Skips the cutscene at the start of the game";

        public override string Name => "Cutscene Skipper";

        public override string HarmonyIdentifier()
        {
            return "mod.id107.cutsceneskipper";
        }
    }
}
