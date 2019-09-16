using Ddd.DotNet.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Ddd.DotNet.Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Client>
    {
        IEnumerable<Client> SearchByName(String name);
    }
}
