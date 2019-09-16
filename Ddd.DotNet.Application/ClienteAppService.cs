using Ddd.DotNet.Application.Interface;
using Ddd.DotNet.Domain.Entities;
using Ddd.DotNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Application
{
    public class ClienteAppService : BaseAppService<Client>, IClienteAppService
    {
        private readonly IClientService _clientService;

        public ClienteAppService(IClientService clientService) : base(clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<Client> SearchByName(string name)
        {
            return _clientService.SearchByName(name);
        }
    }
}
