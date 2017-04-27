using WebPresence.Common.Config;
using WebPresence.Common.Logging;
using WebPresence.Common.LangUtils;

namespace WebPresence.Service
{
    public static class AdminStartUp
    {
        internal const ApplicationId cApplicationId = ApplicationId.CMS;
        private const string cApplicationName = "WebPresence.AdminService";

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
