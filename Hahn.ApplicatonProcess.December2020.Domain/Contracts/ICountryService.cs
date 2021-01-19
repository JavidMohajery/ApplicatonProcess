using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Contracts
{
    public interface ICountryService
    {
        Task<bool> IsThereCountryWithThisNameAsync(string name, CancellationToken cancellationToken);
    }
}
