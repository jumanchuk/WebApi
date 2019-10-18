using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DTOs.Responses;
using Banco.WebApi.DTOs.Requests;
using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        // GET: api/Products
        /// <summary>
        /// Trae todos los Products.
        /// </summary>
        /// <returns>Lista de todos los productos.</returns>
        [HttpGet]
        public async Task<IEnumerable<ProductsDTO>> GetProducts()
        {
            var products = await _productsService.GetAsync();
            var resources = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
            return resources;
        }

        /// <summary>
        /// Retorna un Producto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un cliente</returns>
        /// <response code="404">Si el Producto no existe</response> 
        /// <response code="200">Devuelve el Producto solicitado</response>
        [HttpGet("{id}", Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts(int id)
        {
            var product = await _productsService.GetProductsByClientId(id);
            if (product == null)
                return NotFound();
            var resources = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(product);
            return Ok(resources);
        }

        /// <summary>
        /// Actualiza un Producto.
        /// </summary>
        /// <remarks>
        /// Ejemplo de request:
        ///
        ///     PUT /Clientes
        ///     {
        ///        "id": "1",
        ///        "apellido": "Perez",
        ///        "nombre": "Juan",
        ///        "fechaNacimiento": "01/01/1990"
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <response code="400">Si el id del query string no es igual al del body</response> 
        /// <response code="200">Devuelve el Producto actualizado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductsDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, [FromBody] ProductUpdateDTO request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var productUpdate = _mapper.Map<ProductUpdateDTO, Products>(request);
            await _productsService.Update(productUpdate);
            var ProductsDTO = _mapper.Map<Products, ProductsDTO>(productUpdate);
            return Ok(ProductsDTO);

        }

    }
}