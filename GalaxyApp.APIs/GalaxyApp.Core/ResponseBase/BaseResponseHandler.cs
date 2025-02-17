using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Core.ResponseBase
{
    public class BaseResponseHandler
    {

        public BaseResponse<T> Success<T>()
        {
            return new BaseResponse<T>()
            {
                IsSuccess = true,
                Status = HttpStatusCode.OK,
            };
        }

        public BaseResponse<T> Success<T>(T TData)
        {
            return new BaseResponse<T>()
            {
                IsSuccess = true,
                Status = HttpStatusCode.OK,
                Data = TData
            };
        }

        public BaseResponse<T> Failed<T>(HttpStatusCode statusCode)
        {
            return new BaseResponse<T>()
            {
                IsSuccess = false,
                Status = statusCode,
                ProcessMessage = statusCode.ToString()
            };

        }

        public BaseResponse<T> Created<T>(T TData)
        {
            return new BaseResponse<T>()
            {
                IsSuccess = true,
                Status = HttpStatusCode.OK,
                ProcessMessage = "Created Successfully",
                Data = TData
            };
        }

        public BaseResponse<T> Updated<T>(T TData)
        {
            return new BaseResponse<T>()
            {
                IsSuccess = true,
                Status = HttpStatusCode.OK,
                ProcessMessage = "Updated Successfully",
                Data = TData
            };
        }

        public BaseResponse<T> Deleted<T>()
        {
            return new BaseResponse<T>()
            {
                IsSuccess = true,
                Status = HttpStatusCode.OK,
                ProcessMessage = "Deleted Successfully"
            };
        }

    }
}
