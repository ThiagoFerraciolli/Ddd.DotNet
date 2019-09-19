using AutoMapper;
using Ddd.DotNet.Application.Interface;
using Ddd.DotNet.Domain.Entities;
using Ddd.DotNet.Domain.Interfaces;
using Ddd.DotNet.MvcWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Ddd.DotNet.MvcWebApi.Controllers
{
    [EnableCors(origins: "*",headers:"*",methods: "*")]
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        // GET: Clientes
        [ResponseType(typeof(IEnumerable<ClientViewModel>))]
        public IEnumerable<ClientViewModel> Get()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clienteApp.GetAll());
            return clienteViewModel;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(ClientViewModel))]
        public IHttpActionResult Get(int id)
        {
            var cliente = _clienteApp.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteViewModel = Mapper.Map<Client, ClientViewModel>(cliente);
            return Ok(clienteViewModel);
        }

        // GET: api/Clientes/name
        [ResponseType(typeof(ClientViewModel))]
        [ActionName("GetName")]
        public IHttpActionResult GetName(string name)
        {
            var cliente = _clienteApp.SearchByName(name);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteViewModel = Mapper.Map<IEnumerable<Client>, IEnumerable< ClientViewModel>>(cliente);
            return Ok(clienteViewModel);
        }

        // POST: api/Clientes
        [ResponseType(typeof(Client))]
        public IHttpActionResult Post([FromBody]ClientViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClientViewModel, Client>(cliente);
                _clienteApp.Add(clienteDomain);
                cliente.Id = clienteDomain.Id;
                return Ok(cliente);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult Put(int id, [FromBody]ClientViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }
            var clienteDomain = Mapper.Map<ClientViewModel, Client>(cliente);
            _clienteApp.Update(clienteDomain);
            return Ok(cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            if (cliente == null)
                return NotFound();
            _clienteApp.Remove(cliente);
            return Ok();
        }// GET: api/Clientes/5
    }
}