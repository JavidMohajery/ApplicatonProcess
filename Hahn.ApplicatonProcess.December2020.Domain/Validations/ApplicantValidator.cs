using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validations
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.FamilyName).MinimumLength(5);
            RuleFor(x => x.Address).MinimumLength(10);
            RuleFor(x => x.CountryOfOrigin).Must(BeAvailableCountry);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(20, 60);
            RuleFor(x => x.Hired).NotNull();
        }

        private bool BeAvailableCountry(string arg)
        {
            var countries = new string[] { "Iran", "Germany" };
            return countries.Contains(arg);
        }
    }
}
