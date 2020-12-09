﻿using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Commands.AdresCommands;
using Commands.TankkaartCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/tankkaart")]
    [ApiController]
    public class TankkaartController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public TankkaartController()
        {
        }

        [HttpPost("/writeapi/tankkaart")]
        public async Task<IActionResult> CreateTankkaart(CreateTankkaartDTO createTankkaartDTO)
        {
            return Ok(await Mediator.Send(new CreateTankkaartCommand { CreateTankkaartDTO = createTankkaartDTO }));
        }

        [HttpPut("/writeapi/tankkaart/update/{id}")]
        public async Task<IActionResult> UpdateTankkaart(UpdateTankkaartDTO updateTankkaartDTO)
        {
            return Ok(await Mediator.Send(new UpdateTankkaartCommand { UpdateTankkaartDTO = updateTankkaartDTO }));
        }

        [HttpDelete("/writeapi/tankkaart/delete/{id}")]
        public async Task<IActionResult> DeleteTankkaart(long id)
        {
            return Ok(await Mediator.Send(new DeleteTankkaartCommand { Id = id }));
        }
    }
}
