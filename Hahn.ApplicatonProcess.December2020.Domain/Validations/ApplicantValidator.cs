using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Contracts;
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
        private readonly ICountryService _countryService;

        public ApplicantValidator(ICountryService countryService)
        {
            _countryService = countryService;

            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.FamilyName).MinimumLength(5);
            RuleFor(x => x.Address).MinimumLength(10);
            RuleFor(x => x.CountryOfOrigin)
                .MustAsync(async (name, cancellation) => await _countryService.IsThereCountryWithThisNameAsync(name, cancellation))
                .WithMessage("Specified Country for CountryOfOrigin is not valid");
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(20, 60);
            RuleFor(x => x.Hired).NotNull();
        }
    }
}
