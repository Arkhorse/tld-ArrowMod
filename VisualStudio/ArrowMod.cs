namespace ArrowMod
{
    internal class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
            Logger.LogStarter();
        }
    }
}