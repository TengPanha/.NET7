using System.Runtime.InteropServices;

namespace DotNetTutorail.Response
{
    public class BaseResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public int code { get; set; } = 0;

    }
}
