using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bizlite.SharedLib.DTO
{
    public class BaseApiResponseModel<T>
    {
        public HttpStatusCode? StatusCode { get; set; } = HttpStatusCode.OK;
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string[]? Errors { get; set; }
    }
}
