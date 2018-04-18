using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DataAsync.Helper
{
    public abstract class FileUploadResult
    {
        public static object IsSuccess(bool isSuccess, string msg, dynamic data, HttpStatusCode httpCode = HttpStatusCode.OK)
        {
            return new { isSuccess = isSuccess, msg = msg, data = data, httpCode = httpCode };
        }

        public static object Success(string msg, dynamic data = null, int count = 0, HttpStatusCode httpCode = HttpStatusCode.OK)
        {
            return new { isSuccess = true, msg = msg, data = data, count = count, httpCode = httpCode };
        }

        public static object Error(string msg, int? errorCode = 0, int errorLevel = 0, HttpStatusCode httpCode = HttpStatusCode.InternalServerError)
        {
            return new { isSuccess = false, msg = msg, errorCode = errorCode, errorLevel = errorLevel, httpCode = httpCode };
        }
    }
}