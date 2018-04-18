using DataAsync.Helper;
using DataAsync.Models;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Clearcove.Logging;

namespace WebApp.Controllers
{
    /// <summary>
    /// 文件上传、下载操作
    /// </summary>
    [RoutePrefix("files")]
    public class FilesController : Controller
    {
        static string uploadPath = ConfigurationManager.AppSettings["ServerUploadFolder"]; //从webconfig中获取服务器端文件上传路径

        // GET: Files
        [HttpGet, ActionName("test")]
        public ActionResult Get()
        {
            return Json(new { var1 = 1, var2 = 2, var3 = 3 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateMimeMultipartContentFilter]
        public async Task<ActionResult> FileUpload()
        {
            if (ModelState.IsValid)
            {
                foreach (string file in Request.Files)
                {
                    long totalSize = 0; // 文件总大小
                    int chunkSize; //分块大小
                    string relativePath; //文件夹上传的时候文件的相对路径
                    int totalChunks; //前端文件分块总数
                    int chunkNumber; //当前块的次序，第一个块是 1，注意不是从 0 开始的
                    int currentChunkSize; //当前块的大小
                    string fileName;
                    int bockLength = 0;

                    var fileDataContent = Request.Files[file];
                    if (fileDataContent != null && fileDataContent.ContentLength > 0)
                    {
                        totalSize = long.Parse(Request.Form["totalSize"]);
                        chunkSize = Int32.Parse(Request.Form["chunkSize"]);
                        relativePath = Request.Form["relativePath"];
                        chunkNumber = Int32.Parse(Request.Form["chunkNumber"]);
                        currentChunkSize = Int32.Parse(Request.Form["currentChunkSize"]);
                        totalChunks = Int32.Parse(Request.Form["totalChunks"]);
                        fileName = Path.GetFileName(fileDataContent.FileName);
                        string targetPath = null; //文件夹中的子文件夹

                        //如果上传的是文件夹，先创建好文件夹的路径
                        if (relativePath.Contains("/") && relativePath != fileName)
                            targetPath = uploadPath + $@"\" + relativePath.Replace($@"/{fileName}", "");
                        else
                            targetPath = uploadPath;

                        FileStream fs = null;

                        try
                        {
                            if (!Directory.Exists(targetPath))
                                Directory.CreateDirectory(targetPath);

                            //实际文件的路径
                            string fileFullName = Path.Combine(targetPath, fileName);

                            //文件已存在，删除
                            if (System.IO.File.Exists(fileFullName))
                                System.IO.File.Delete(fileFullName);

                            //构建与要上传文件大小相同的文件  
                            fs = new FileStream(fileFullName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                            fs.SetLength(totalSize);
                            await fs.FlushAsync();
                            fs.Close();

                            Stream st = fileDataContent.InputStream;
                            byte[] bytesBock = new byte[st.Length];
                            st.Read(bytesBock, 0, (int)st.Length);
                            fs = new FileStream(fileFullName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                            int offset = (chunkNumber - 1) * chunkSize;//写入文件偏移量
                            bockLength = bytesBock.Length;
                            //写入字节流
                            fs.Seek(offset, SeekOrigin.Begin);//移动到要写入的位置
                            await fs.WriteAsync(bytesBock, 0, bockLength);
                            await fs.FlushAsync();
                            fs.Close();
                        }
                        catch (Exception e)
                        {
                            await fs.FlushAsync();
                            fs.Close();
                            if (fileName != null)
                                return Json(FileUploadResult.Error(e.Message), JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }

            string message = $"{Request.Files.Count} file(s)" + $"{(long.Parse(Request.Form["totalSize"]) / 1024 / 1024).ToString("0.0000")} MB uploaded successfully!";
            return Json(FileUploadResult.Success(message, Request.Files.Count), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 压缩、删除文件
        /// </summary>
        /// <param name="isFolder"> 是否是文件夹，只有文件夹的时候才打包 </param>
        /// <param name="sourDir"> 要压缩的目录 </param>
        /// <param name="isCancle"> 是否确定上传 </param>
        [HttpGet, ActionName("handlefile")]
        public ActionResult ZipFiles(bool isFolder, string sourDir, int? equipmentID, int? experimentID, bool isCancle = false)
        {
            //验证参数合法性
            if (!isCancle && (equipmentID == null || experimentID == null))
                return Json(FileUploadResult.IsSuccess(false, "参数不合法，请重新上传", null), JsonRequestBehavior.AllowGet);

            string dirToZip = uploadPath + $@"\{sourDir}"; //需要压缩的目录
            string zipName = uploadPath + $@"\{sourDir}.zip"; //压缩包的名称
            string dbFile = null; //db文件
            string fileName = null;
            string result = "Failure"; //db文件同步结果

            if (isCancle)
            {
                DataRewind(isFolder, sourDir, experimentID);

                return Json(FileUploadResult.IsSuccess(false, "已取消上传", null), JsonRequestBehavior.AllowGet);
            }

            //如果上传的是单个db文件，直接解密,并调用数据同步服务
            if (isFolder == false && sourDir.Contains(".db"))
            {
                dbFile = uploadPath + $@"\{sourDir}";
                fileName = sourDir;

                if (FileDecrypt.DbDecrypt(dbFile))
                    result = DataAsync.Helper.DataAsync.DbAsync(dbFile, equipmentID, experimentID);
            }

            //上传的文件夹，找到db文件将其解密，并调用数据同步服务
            if (isFolder)
            {
                //dbFile = Directory.GetFiles(uploadPath + $@"\{sourDir}").Where(t => t.Contains(".db")).FirstOrDefault();

                var directory = new DirectoryInfo(uploadPath + $@"\{sourDir}");

                var dbFiles = FileExtensions.AllFilesAndFolders(directory).Where(t => t.Extension.Contains(".db")).ToList();

                if (dbFiles.Count > 1)
                {
                    DataRewind(isFolder, sourDir, experimentID);
                    return Json(FileUploadResult.IsSuccess(false, "包含多个db文件", null), JsonRequestBehavior.AllowGet);
                }


                dbFile = dbFiles[0].FullName;

                if (dbFile != null)
                    if (FileDecrypt.DbDecrypt(dbFile))
                        result = DataAsync.Helper.DataAsync.DbAsync(dbFile, equipmentID, experimentID);
                fileName = $@"{sourDir}.zip";
            }

            if (result == "Success")
            {
                //db文件名
                var dbFileName = Path.GetFileNameWithoutExtension(dbFile);
                //实验运行时间
                var _run_time = Regex.Matches(dbFileName, @"[0-9]+-", RegexOptions.IgnorePatternWhitespace);

                //设备编号
                var equipment_Code = Regex.Match(dbFileName, @"-[A-Za-z0-9]+_", RegexOptions.IgnorePatternWhitespace).ToString();
                var run_Time = new DateTime();
                //将文件上传记录更新到数据库,并删除上传的文件夹
                var files = new TB_Uploaded_Log
                {
                    File_Name = fileName,
                    Equipment_Code = equipment_Code.Substring(1, equipment_Code.Length - 2),
                    Created_Time = DateTime.UtcNow.AddHours(8),
                    Updated_Time = DateTime.UtcNow.AddHours(8)
                };

                try
                {
                    using (var db = new GnexEntities())
                    {
                        run_Time = DateTime.ParseExact(_run_time[0].ToString().Substring(0, _run_time[0].Length - 1), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                        db.TB_Uploaded_Log.Add(files);

                        //更新TB_Experiment中的File_Path_ID
                        var exTOUpdate = db.TB_Experiment.Where(t => t.ID == experimentID && t.Is_Effective == true).SingleOrDefault();
                        exTOUpdate.TB_Uploaded_Log = files;
                        db.Entry(exTOUpdate).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    if (isFolder)
                    {
                        //压缩文件已存在先删除
                        if (System.IO.File.Exists(zipName))
                            System.IO.File.Delete(zipName);

                        //创建压缩文件
                        ZipFile.CreateFromDirectory(dirToZip, zipName, CompressionLevel.Optimal, true, Encoding.UTF8);
                    }
                }
                catch (Exception e)
                {
                    return Json(FileUploadResult.Error(e.Message), JsonRequestBehavior.AllowGet);
                }
                finally
                {
                    if (isFolder)
                        Directory.Delete(uploadPath + $@"\{sourDir}", true);
                }

                return Json(FileUploadResult.Success($"/src/Files/{sourDir}"), JsonRequestBehavior.AllowGet);
            }
            //文件解析失败则删除上传的文件/文件夹和压缩包
            else
            {
                DataRewind(isFolder, sourDir, experimentID);

                return Json(FileUploadResult.Error("文件同步失败", errorCode: experimentID), JsonRequestBehavior.AllowGet);
            }
        }

        public void DataRewind(bool isFolder, string sourDir, int? experimentID)
        {
            try
            {

                if (isFolder)
                    Directory.Delete(uploadPath + $@"\{sourDir}", true); //删除文件夹
                else
                    System.IO.File.Delete(uploadPath + $@"\{sourDir}");

                //已同步的数据进行回滚
                using (var con = new GnexEntities())
                {
                    var tb_Experiment = con.TB_Experiment.Where(t => t.ID == experimentID).SingleOrDefault();
                    con.TB_Fluorescence.RemoveRange(tb_Experiment.TB_Fluorescence);
                    con.TB_Patient.RemoveRange(tb_Experiment.TB_Patient);
                    con.TB_Experiment_Result.RemoveRange(tb_Experiment.TB_Experiment_Result);
                    con.TB_Experiment_Info.RemoveRange(tb_Experiment.TB_Experiment_Info);
                    con.TB_OpEnvironment.RemoveRange(tb_Experiment.TB_OpEnvironment);
                    con.TB_Experiment.Remove(tb_Experiment);
                    con.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}