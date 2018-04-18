using Microsoft.SqlServer.Dts.Runtime;
using System;
using Clearcove.Logging;
using System.IO;

namespace DataAsync.Helper
{
    public class DataAsync
    {
        public static string DbAsync(string dataSource, int? equipmentID, int? experimentID)
        {
            string pkgLocation = @"D:\DataSync\DataSync\Package.dtsx"; //数据同步服务包的位置
            string result = "Failure";
            var app = new Application();
            var pkg = app.LoadPackage(pkgLocation, null);
            var targetLogFile = new FileInfo(Path.Combine(@"D:\Data Async\logs\", $"{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}.log"));
            //日志记录初始化
            Logger.Start(targetLogFile);

            //给package中的变量dataSource赋值
            pkg.Variables["dataSource"].Value = dataSource;
            pkg.Variables["equipmentID"].Value = (Int32)equipmentID;
            pkg.Variables["experimentID"].Value = (Int32)experimentID;

            //执行包
            result = pkg.Execute().ToString();

            if (result != "Success")

                //记录错误
                try
                {
                    //日志记录名称为"DataAsync"
                    var log = new Logger(typeof(DataAsync)); 
                    for (var i = 0; i < pkg.Errors.Count; i++)
                        log.Error(pkg.Errors[i].Source + "-" + pkg.Errors[i].SubComponent + ":" + pkg.Errors[i].Description);
                }
                finally
                {
                    Logger.ShutDown(); 
                    pkg.Dispose();
                }

            return result;
        }
    }
}