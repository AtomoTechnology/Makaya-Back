using Customer.Service.EventHandlers.Commands.User;
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
    [Route("api/v1/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserQueryService _service;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger,
            IMediator mediator,
            IUserQueryService service)
        {
            _logger = logger;
            _mediator = mediator;
            _service = service;
        }

        [HttpGet]
        public async Task<DataCollection<UserDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<Int64> countries = null;

            if (!string.IsNullOrEmpty(ids))
            {
                countries = ids.Split(',').Select(x => Convert.ToInt64(x));
            }
            return await _service.GetAllAsync(page, take, countries);
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Publish(new UserDeleteCommand { UserId = id });
            return NoContent();
        }
    }
}
