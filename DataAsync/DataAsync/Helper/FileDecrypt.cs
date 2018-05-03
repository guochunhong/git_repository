using System;
using System.Data.SQLite;

namespace DataAsync.Helper
{
    /// <summary>
    /// 解密DB文件
    /// </summary>
    public class FileDecrypt
    {
        private static readonly string password = "pv123*456";

        public static bool DbDecrypt(string dataSource)
        {
            using (var connection = new SQLiteConnection($@"Data Source = {dataSource}"))
            {
                connection.SetPassword(password);
                try
                {
                    connection.Open();
                    connection.ChangePassword("");
                }
                catch (SQLiteException e)
                {
                    if (e.ErrorCode == 26) //DB文件已经解密过.
                        return true;

                }
                finally
                {
                    connection.Dispose();
                }
                return true;
            }
        }
    }
}


