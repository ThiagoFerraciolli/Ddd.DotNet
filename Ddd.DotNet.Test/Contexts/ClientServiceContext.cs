using AutoMoq;
using Ddd.DotNet.Domain.Interfaces;
using Ddd.DotNet.Domain.Services;
using Moq;

namespace Ddd.DotNet.Test
{

    public class ClientServiceContext
    {
        private readonly AutoMoqer mocker;

        public Mock<IClienteRepository> ClienteRepository { get; set; }

        public ClientServiceContext()
        {
            mocker = new AutoMoqer();

            ClienteRepository = mocker.GetMock<IClienteRepository>();
        }

        public ClientService Create() => mocker.Create<ClientService>();

        public ClientService Create(IClienteRepository clienteRepository) 
            => new ClientService(clienteRepository);
    }
}
