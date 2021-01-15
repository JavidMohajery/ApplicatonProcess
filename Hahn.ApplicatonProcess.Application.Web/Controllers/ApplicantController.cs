using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Application.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        [HttpGet]
        [Route("GetById")]
        public JsonResult GetById(int id)
        {
            return new JsonResult(new Applicant() { Id = id});
        }
        [HttpPost]
        [Route("Create")]
        public JsonResult Create(Applicant applicant)
        {
            return new JsonResult(applicant);
        }
        [HttpPost]
        [Route("Update")]
        public JsonResult Update(Applicant applicant)
        {
            return new JsonResult(applicant);
        }
        [HttpPost]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            return new JsonResult(new Applicant());
        }

    }
}
