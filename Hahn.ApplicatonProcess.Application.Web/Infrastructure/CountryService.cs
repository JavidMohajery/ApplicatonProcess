using Hahn.ApplicatonProcess.December2020.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Application.Web.Infrastructure
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> IsThereCountryWithThisNameAsync(string name, CancellationToken cancellationToken)
        {
            var address = $"https://restcountries.eu/rest/v2/name/{name}?fullText=true";
            _httpClient.BaseAddress = new Uri(address);
            var result = await _httpClient.GetAsync(address, cancellationToken);
            if (result.StatusCode == System.Net.HttpStatusCode.NotFound) return false;
            return true;
        }
    }
}
