using WebPresence.Common.Config;
using WebPresence.Common.Logging;
using WebPresence.Common.LangUtils;

namespace WebPresence.Core
{
    public static class StartUp
    {
        internal const ApplicationId cApplicationId = ApplicationId.CMS;
        private const string cApplicationName = "WebPresence.Core";

        private static RunOnce _runOnce = new RunOnce(RunStartup);


        public static void StartupOnce()
        {
            _runOnce.Run();
        }

        private static void RunStartup()
        {
            LogManager.Instance.Configure(cApplicationName, ConfigSettings.LogFilePath);
            PerformanceLogMgr.Instance.Configure(ConfigSettings.PerformanceLogPath);
        }
    }
}
