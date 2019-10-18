using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DTOs.Responses;
using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Banco.WebApi.DTOs.Requests;

namespace WebApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientesController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        // GET: api/Clientes
        /// <summary>
        /// Trae todos los clientes.
        /// </summary>
        /// <returns>Lista de todos los clientes.</returns>
        [HttpGet]
        public async Task<IEnumerable<ClienteDTO>> Get()
        {
            var clientes = await _clientService.GetAsync();
            var resources = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(clientes);
            return resources;
        }

        /// <summary>
        /// Retorna un cliente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un cliente</returns>
        /// <response code="404">Si el cliente no existe</response> 
        /// <response code="200">Devuelve el cliente solicitado</response>
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _clientService.GetById(id);
            if (cliente == null)
                return NotFound();
            var resources = _mapper.Map<Cliente, ClienteDTO>(cliente);
            return Ok(resources);
        }

        /// <summary>
        /// Crea un cliente.
        /// </summary>
        /// <remarks>
        /// Ejemplo de request:
        ///
        ///     POST /Cliente
        ///     {
        ///        "Document": 0,
        ///        "name": "Juan",
        ///        "lastname": "Perez",
        ///        "Date": "2019-10-11"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>Un nuevo cliente creado</returns>
        /// <response code="201">Devuelve el nuevo cliente creado</response>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<ClienteDTO>> Post([FromBody] ClienteAddDTO request)
        {
            var cliente = _mapper.Map<ClienteAddDTO, Cliente>(request);
            await _clientService.AddAsync(cliente);
            var clienteDTO = _mapper.Map<Cliente, ClienteDTO>(cliente);
            return CreatedAtAction("Get", new { id = cliente.Id }, clienteDTO);
        }

    }
}
