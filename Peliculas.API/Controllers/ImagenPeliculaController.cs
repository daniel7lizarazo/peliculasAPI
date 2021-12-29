using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Application.DTOs;
using Peliculas.Application.Interfaces;
using Peliculas.Application.Utils;
using Peliculas.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenPeliculaController : ControllerBase
    {
        private readonly IImagenPeliculaService _imagenPeliculaService;
        public ImagenPeliculaController(IImagenPeliculaService imagenPeliculaService,
            IHttpContextAccessor host,
            IWebHostEnvironment env)
        {
            _imagenPeliculaService = imagenPeliculaService;
            if(string.IsNullOrEmpty(AppVariables.RootPath))
                AppVariables.RootPath = $"{host.HttpContext.Request.Scheme}://{host.HttpContext.Request.Host}";
        }

        [HttpPost]
        public async Task<IActionResult> Post(ImagenPeliculaDTO request)
        {
            return Ok(await _imagenPeliculaService.Add(request));
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByPeliculaId(Guid id)
        {
            return Ok(_imagenPeliculaService.GetByPeliculaId(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([Required]Guid id)
        {
            await _imagenPeliculaService.Delete(id);
            return Ok();
        }
    }
}
