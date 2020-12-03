﻿using DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
using WriteRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Linq;
using Commands.AdresCommands;

namespace WriteApi.Controllers
{
    [Route("writeapi/adres")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly INHRepository<Adres> _adresContext;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public AdresController(INHRepository<Adres> adresContext)
        {
            _adresContext = adresContext;
        }

        [HttpPost("/writeapi/adres")]
        public async Task<IActionResult> CreateAdres(CreateAdresDTO createAdresDTO)
        {
            return Ok(await Mediator.Send(new CreateAdresCommand { CreateAdresDTO = createAdresDTO }));
        }

        [HttpPut("/writeapi/adres/update/{id}")]
        public async Task<IActionResult> UpdateAdres(UpdateAdresDTO updateAdresDTO)
        {
            return Ok(await Mediator.Send(new UpdateAdresCommand { UpdateAdresDTO = updateAdresDTO }));
        }

        [HttpDelete("/writeapi/adres/delete/{id}")]
        public async Task<IActionResult> DeleteAdres(long id)
        {
            //kijken of adres bestaat
            var adres = _adresContext.Adressen.FirstOrDefault(a => a.Id == id);

            //met mediatr teruggeven ipv ex
            //custom validator maken? logica naar daar verhuizen niet zo goed
            //dbcontext in validator injecteren dan
            if (adres == null)
            {
                return Ok("Adres bestaat niet");
            }
            else
            {
                return Ok(await Mediator.Send(new DeleteAdresCommand { Id = id }));
            }
        }
    }
}
