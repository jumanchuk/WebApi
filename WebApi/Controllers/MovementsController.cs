using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Responses;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]

    public class MovementsController : ControllerBase
    {

        private readonly IMovementService _movementService;
        private readonly IMapper _mapper;

        public MovementsController(IMovementService movementService, IMapper mapper)
        {
            _movementService = movementService;
            _mapper = mapper;
        }

        [HttpGet(Name = "Search")]
        public async Task<IActionResult> Search
          (
              int Id,
              int? pageNumber = 1,
              int? pageSize = 10
          )
        {
            var movements = await _movementService.SearchAsync(Id, pageNumber.Value, pageSize.Value);
            if (!movements.Any())
                return NotFound();
            var movementsDTO = _mapper
                .Map<IEnumerable<Movements>, IEnumerable<MovementsDTO>>(movements);
            return Ok(movementsDTO);
        }

    }
}