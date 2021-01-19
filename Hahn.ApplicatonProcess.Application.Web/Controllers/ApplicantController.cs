using Hahn.ApplicatonProcess.December2020.Data;
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

        private readonly AppDbContext _dbContext;

        public ApplicantController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Applicant applicant = _dbContext.Applicants.Find(id);
            return Ok(applicant);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Applicant applicant)
        {
            _dbContext.Applicants.Add(applicant);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = applicant.Id }, applicant);
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Applicant applicant)
        {
            var inDbApplicant = _dbContext.Applicants.Find(applicant.Id);
            if (inDbApplicant != null)
            {
                inDbApplicant.Name = applicant.Name;
                inDbApplicant.FamilyName = applicant.FamilyName;
                inDbApplicant.Address = applicant.Address;
                inDbApplicant.CountryOfOrigin = applicant.CountryOfOrigin;
                inDbApplicant.EmailAddress = applicant.EmailAddress;
                inDbApplicant.Age = applicant.Age;
                inDbApplicant.Hired = applicant.Hired;

                _dbContext.Applicants.Update(inDbApplicant);
                _dbContext.SaveChanges();
            }

            return Ok(applicant);
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var inDbApplicant = _dbContext.Applicants.Find(id);
            if (inDbApplicant == null) return null;
            _dbContext.Applicants.Remove(inDbApplicant);
            _dbContext.SaveChanges();

            return Ok(inDbApplicant);
        }

    }
}
