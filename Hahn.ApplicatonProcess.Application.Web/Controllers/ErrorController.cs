using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Application.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        public ErrorController()
        {

        }
        [Route("api/error")]
        public IActionResult LogError()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionFeature != null)
            {
                string path = exceptionFeature.Path;
                var exception = exceptionFeature.Error;
                Log.Error(exception, path);
                var error = new { ErrorMessahe = exception.Message, ErrorPath = path };
                
                return BadRequest(error);
            }
            return BadRequest();
        }
    }
}
