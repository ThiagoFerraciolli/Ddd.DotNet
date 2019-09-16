using Ddd.DotNet.Domain.Entities;
using Ddd.DotNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Domain.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IClienteRepository _clientRepository;
        public ClientService(IClienteRepository clientRepository) : base(clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> SearchByName(string name)
        {
            return _clientRepository.SearchByName(name);
        }
    }
}
