using Ddd.DotNet.Domain.Entities;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ddd.DotNet.Test
{
    public class ClientServiceTest
    {
        private readonly ClientServiceContext _clientServiceContext;

        public ClientServiceTest()
        {
            _clientServiceContext = new ClientServiceContext();
        }

        [Fact]
        public void ShouldCallGetAllFromOnceTime()
        {
            _clientServiceContext.ClienteRepository
                .Setup(x => x.GetAll())
                .Returns(new Client[0]);

            var target = _clientServiceContext.Create();

            target.GetAll();

            _clientServiceContext.ClienteRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void ShouldReturnDataFromRepositoryWhenCallingGetAll()
        {
            var clientes = new[]
            {
                new Client {Id=1,Name="teste",Phone="123456789"}
            };

            _clientServiceContext.ClienteRepository
                .Setup(x => x.GetAll())
                .Returns(clientes);

            var target = _clientServiceContext.Create();

            var result = target.GetAll();
            
            result.ShouldNotBeEmpty();
            result.ShouldHaveSingleItem();
            result.ShouldContain(x => x.Name == "teste");
        }


        [Fact]
        public void ShouldReturnDataFromRepositoryWhenCallingSerachByName()
        {
            IEnumerable<Client> clientes = new[]
            {
                new Client {Id=1,Name="teste",Phone="123456789"},
                new Client {Id=2,Name="testando",Phone="123456789"}
            };

            string aux = null;
            _clientServiceContext.ClienteRepository
                .Setup(x => x.SearchByName(It.IsAny<string>()))
                .Callback((string obj)=> { aux =  obj; })
                .Returns(clientes.Where(c=>c.Name == aux));

            var target = _clientServiceContext.Create();

            var result = target.SearchByName("teste"); ;

            result.ShouldNotBeEmpty();
            result.ShouldHaveSingleItem();
            result.ShouldContain(x => x.Name == "teste");
        }

        [Fact]
        public void ShouldReturnDataAddAfterCallingAdd()
        {
            Client cliente = new Client { Id = 1, Name = "teste", Phone = "123456789" };
            Client result = null;

            _clientServiceContext.ClienteRepository
                .Setup(x => x.Add(It.IsAny<Client>()))
                .Callback((Client obj) => {
                    result = obj;
                });
            var target = _clientServiceContext.Create();
                       
            target.Add(cliente);
            _clientServiceContext.ClienteRepository.Verify(x => x.Add(It.IsAny<Client>()), Times.Once);
            //result.Equals(cliente);
            result.ShouldNotBeNull();
            result.ShouldBe(cliente);
        }


        [Fact]
        public void ShouldReturnDataUpdateAfterCallingUpdate()
        {
            Client cliente = new Client { Id = 1, Name = "teste1", Phone = "123456789" };
            Client result = null;

            
            _clientServiceContext.ClienteRepository
                .Setup(x => x.Update(It.IsAny<Client>()))
                .Callback((Client obj) => {
                    result = obj;
                });
            var target = _clientServiceContext.Create();

            _clientServiceContext.ClienteRepository
                .Object.Add(cliente);

            target.Update(new Client { Id = 1, Name = "teste1", Phone = "123456789" });
            _clientServiceContext.ClienteRepository.Verify(x => x.Update(It.IsAny<Client>()), Times.Once);
           result.ShouldNotBeNull();
        }
    }
}
