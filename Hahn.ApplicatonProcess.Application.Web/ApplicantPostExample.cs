using Hahn.ApplicatonProcess.December2020.Domain.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Application.Web
{
    public class ApplicantPostExample : IExamplesProvider<Applicant>
    {
        public Applicant GetExamples()
        {
            //all valid values
            return new Applicant
            {
                Name = "Javid",
                FamilyName = "Mohajery",
                Address = "Test Address 123",
                CountryOfOrigin = "Islamic Republic Of Iran",
                Age = 30,
                EmailAddress = "javidmohajery@gmail.com",
                Hired = true
            };
        }
    }
}
