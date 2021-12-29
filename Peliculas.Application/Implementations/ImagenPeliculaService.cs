using Peliculas.Application.DTOs;
using Peliculas.Application.Interfaces;
using Peliculas.Application.Utils;
using Peliculas.Domain.Entities;
using Peliculas.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Application.Implementations
{
    public class ImagenPeliculaService : IImagenPeliculaService
    {
        private readonly IAlmacenarArchivos _almacenarArchivos;
        private readonly IRepository<ImagenPelicula,Guid> _repository;
        private const string _contenedor = "ImagenesPeliculas";

        public ImagenPeliculaService(IAlmacenarArchivos almacenarArchivos, IRepository<ImagenPelicula,Guid> repository)
        {
            _almacenarArchivos = almacenarArchivos;
            _repository = repository;
        }
        public async Task<ImagenPelicula> Add(ImagenPeliculaDTO imagenPeliculaDTO)
        {
            var ruta = await _almacenarArchivos
                .GuardarArchivo(imagenPeliculaDTO.ImagenBase64,
                imagenPeliculaDTO.Extension,
                _contenedor
                );
            var entity = new ImagenPelicula()
            {
                Path = ruta,
                Nombre = imagenPeliculaDTO.Nombre,
                PeliculaId = imagenPeliculaDTO.PeliculaId
            };

            return _repository.Add(entity);
        }

        public List<ImagenPelicula> GetByPeliculaId(Guid Id)
        {
            return _repository.GetByFilter(x => x.PeliculaId == Id);
        }

        public async Task Delete(Guid Id)
        {
            var entity = _repository.GetById(Id);
            await _almacenarArchivos.EliminarArchivo(entity.Path, _contenedor);
            _repository.Delete(Id);
        }
    }
}
