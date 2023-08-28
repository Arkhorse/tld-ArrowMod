using MelonLoader;


namespace ArrowMod
{
    internal class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
            LoggerInstance.Msg($"[{BuildInfo.ModName}] Version {BuildInfo.ModVersion} loaded!");
        }
    }
}