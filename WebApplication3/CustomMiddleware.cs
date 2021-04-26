using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace WebApplication3
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["User-Agent"].ToString() == "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.128 Safari/537.36 Edg/89.0.774.77")
            {
                httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana");
            }
            return next(httpContext);
        }
    }
}
