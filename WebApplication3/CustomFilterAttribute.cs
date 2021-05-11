using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3
{
    public class CustomFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //*
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            /*/
            var ipAddress = context.HttpContext.Request.Host.ToString();//*/
            var result = (PageResult)context.Result;
            result.ViewData["IpAddress"] = ipAddress;
            await next.Invoke();
        }
    }
}
