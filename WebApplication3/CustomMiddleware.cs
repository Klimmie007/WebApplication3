using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Shyjus.BrowserDetection;

namespace WebApplication3
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext, IBrowserDetector detector)
        {
            var browser = detector.Browser;
            if (browser.Name == BrowserNames.Edge || browser.Name == BrowserNames.EdgeChromium 
                || browser.Name == BrowserNames.InternetExplorer)
            {
                httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana");
            }
            return next(httpContext);
        }
    }
}
