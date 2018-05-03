using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DataAsync.Helper
{
    public static class FileExtensions
    {

        public static IEnumerable<FileSystemInfo> AllFilesAndFolders(this DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
                yield return file;
            foreach (var dir in directory.GetDirectories())
            {
                yield return dir;

                foreach (var file in AllFilesAndFolders(dir))
                    yield return file;
            }
        }
    }
}