using Customer.Service.EventHandlers.Commands.Country.Create;
using Customer.Service.EventHandlers.Commands.Country.Delete;
using Customer.Service.EventHandlers.Commands.Country.Update;
using Customer.Service.EventHandlers.Commands.Province;
using Customer.services.queries.DTOs;
using Customer.services.queries.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.API.Controllers
{
    [Route("api/v1/Provinces")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly ILogger<ProvincesController> _logger;
        private readonly IProvinceQueryService _service;
        private readonly IMediator _mediator;

        public ProvincesController(ILogger<ProvincesController> logger,
          IMediator mediator,
          IProvinceQueryService service)
        {
            _logger = logger;
            _mediator = mediator;
            _service = service;
        }
        [HttpGet]
        public async Task<DataCollection<ProvinceDTO>> GetAll(int page = 1, int take = 10, Int64 CountryId = 0, bool isFilter = false, string ids = null)
        {
            IEnumerable<Int64> countries = null;

            if (!string.IsNullOrEmpty(ids))
            {
                countries = ids.Split(',').Select(x => Convert.ToInt64(x));
            }
            return await _service.GetAllAsync(page, take, CountryId, isFilter, countries);
        }
        [HttpGet("{id}")]
        public async Task<ProvinceDTO> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProvinceCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProvinceUpdateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Publish(new ProvinceDeleteCommand { ProvinceId = id });

            return NoContent();
        }
    }
}
