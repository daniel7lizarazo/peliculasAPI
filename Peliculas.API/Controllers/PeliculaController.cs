using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Application.Interfaces;
using Peliculas.Domain.Entities;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : BaseController<Pelicula, Guid>
    {
        private readonly IImagenPeliculaService _imagenPeliculaService;
        public PeliculaController(ICrudService<Pelicula, Guid> crudService, IImagenPeliculaService imagenPeliculaService) : base(crudService)
        {
            _imagenPeliculaService = imagenPeliculaService;
        }

        [HttpDelete]
        [Route("{id}")]
        public override IActionResult Delete(Guid id)
        {
            _crudService.Delete(id);
            _imagenPeliculaService.GetByPeliculaId(id).ForEach(x =>
            {
                _imagenPeliculaService.Delete(x.Id);
            });
            return Ok();
        }

    }
}
