using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class Status
    {
        public Status(HttpStatusCode statusCode, string? message, object? data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
