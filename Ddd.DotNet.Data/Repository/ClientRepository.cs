using Ddd.DotNet.Domain.Entities;
using Ddd.DotNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Data.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClienteRepository
    {
        public IEnumerable<Client> SearchByName(string name)
        {
            return Db.Clients.Where(c => c.Name == name);
        }
    }
}
