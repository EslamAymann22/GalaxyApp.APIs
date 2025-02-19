using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Core.ResponseBase.GeneralResponse
{
    public class BaseResponse<T>
    {

        public HttpStatusCode Status { get; set; }
        public bool IsSuccess { get; set; }
        public object? Data { get; set; }
        public string? ProcessMessage { get; set; }

        public BaseResponse()
        {
            Status = HttpStatusCode.OK;
            IsSuccess = true;
            ProcessMessage = "Process is Successfully";
        }

    }
}
