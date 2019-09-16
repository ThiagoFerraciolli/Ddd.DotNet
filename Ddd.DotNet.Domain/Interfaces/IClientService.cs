using Ddd.DotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Domain.Interfaces
{
    public interface IClientService : IBaseService<Client>
    {
        IEnumerable<Client> SearchByName(String name);
    }
}
