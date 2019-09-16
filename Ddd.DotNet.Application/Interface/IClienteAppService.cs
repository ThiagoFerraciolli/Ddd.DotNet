using Ddd.DotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Application.Interface
{
    public interface IClienteAppService : IBaseAppService<Client>
    {
        IEnumerable<Client> SearchByName(String name);
    }
}
