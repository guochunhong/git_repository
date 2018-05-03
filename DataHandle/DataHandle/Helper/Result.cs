using System.Net;

namespace Helper
{
    public abstract class Result
    {
        public static object IsSuccess(int result, string msg, dynamic data)
        {
            return new { result = result, msg = msg, data = data };
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