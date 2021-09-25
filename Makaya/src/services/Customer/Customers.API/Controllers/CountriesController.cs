using Customer.Service.EventHandlers.Commands.Country.Create;
using Customer.Service.EventHandlers.Commands.Country.Delete;
using Customer.Service.EventHandlers.Commands.Country.Update;
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
    [ApiController]
    [Route("api/v1/Countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountryQueryService _service;
        private readonly IMediator _mediator;

        public CountriesController(ILogger<CountriesController> logger,
            IMediator mediator,
            ICountryQueryService service)
        {
            _logger = logger;
            _mediator = mediator;
            _service = service;
        }

        [HttpGet]
        public async Task<DataCollection<CountryDTO>> GetAll(int page = 1, int take = 10,bool isFilter = false, string ids = null)
        {
            IEnumerable<Int64> countries = null;

            if (!string.IsNullOrEmpty(ids))
            {
                countries = ids.Split(',').Select(x => Convert.ToInt64(x));
            }
            return await _service.GetAllAsync(page,take, isFilter, countries);
        }
        [HttpGet("{id}")]
        public async Task<CountryDTO> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CountryUpdateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Publish(new CountryDeleteCommand { CountryId = id });

            return NoContent();
        }
    }
}
