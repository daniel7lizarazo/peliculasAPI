using Peliculas.Application.DTOs;
using Peliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Application.Interfaces
{
    public interface IImagenPeliculaService
    {
        public Task<ImagenPelicula> Add(ImagenPeliculaDTO imagenPeliculaDTO); 
        public List<ImagenPelicula> GetByPeliculaId(Guid Id);
        public Task Delete(Guid Id);
    }
}
