using Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Test.Controllers
{
    [Produces("application/json"), Consumes("application/json", "multipart/form-data")]
    [Route("api/data")]
    public class DataController : Controller
    {
        [Route("selftest"), HttpPost]
        public ActionResult SelfTestInfo([FromBody] dynamic info)
        {
            if (info == null)
            {
                return Json(Result.Error("The data is null."));
            }
            else
            {
                var targetLogFile = new FileInfo(Path.Combine(@"D:\Data\logs\", $"{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}.log"));

                Logger.Start(targetLogFile); // Loggers will complains if you skip initialization

                var log = new Logger("selfTest"); // Create logger with class name.
                try
                {
                    log.Info(info.ToString());
                }
                finally
                {
                    Logger.ShutDown(); // Removing this line may result in lost log entries.
                }
            }

            return Json(Result.IsSuccess(1, null, null));
        }

        [Route("thermalcycling"), HttpPost]
        public ActionResult Thermalcycling([FromBody] dynamic info)
        {
            if (info == null)
            {
                return Json(Result.Error("The data is null."));
            }
            else
            {
                var targetLogFile = new FileInfo(Path.Combine(@"D:\Data\logs\", $"{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}.log"));

                Logger.Start(targetLogFile); // Loggers will complains if you skip initialization

                var log = new Logger("Thermalcycling"); // Create logger with class name.
                try
                {
                    log.Info(info.ToString());
                }
                finally
                {
                    Logger.ShutDown(); // Removing this line may result in lost log entries.
                }
            }

            return Json(Result.IsSuccess(1, null, null));
        }

        [Route("test"), HttpGet]
        public ActionResult test()
        {
            return Json(Result.IsSuccess(1, null, null));
        }
    }
}