using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Agreeya.Account
{
    public class Response
    {
        public Response() { }
        public Response(int statusCode, string status, string message) 
        {
            Status = status;
            Message = message;
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
       

        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
