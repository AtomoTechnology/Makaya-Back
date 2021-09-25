using Customer.Service.EventHandlers.Commands.City;
using Customer.services.queries.DTOs;
using Customer.services.queries.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Controllers
{
    [Route("api/v1/Cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly ICityQueryService _service;
        private readonly IMediator _mediator;

        public CitiesController(ILogger<CitiesController> logger,
            IMediator mediator,
            ICityQueryService service)
        {
            _logger = logger;
            _mediator = mediator;
            _service = service;
        }

        [HttpGet]
        public async Task<DataCollection<CityDTO>> GetAll(int page = 1, int take = 10, Int64 ProvinceId = 0, bool isFilter = false, string ids = null)
        {
            IEnumerable<Int64> countries = null;

            if (!string.IsNullOrEmpty(ids))
            {
                countries = ids.Split(',').Select(x => Convert.ToInt64(x));
            }
            return await _service.GetAllAsync(page, take, ProvinceId, isFilter, countries);
        }
        [HttpGet("{id}")]
        public async Task<CityDTO> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CityUpdateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Publish(new CityDeleteCommand { CityId = id });

            return NoContent();
        }
    }
}