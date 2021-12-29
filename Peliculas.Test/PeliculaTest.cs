using Moq;
using Peliculas.Application.Implementations;
using Peliculas.Application.Interfaces;
using Peliculas.Domain.Entities;
using Peliculas.Domain.Repository;
using Peliculas.Infraestructure;
using Peliculas.Infraestructure.Context;
using System;
using Xunit;

namespace Peliculas.Test
{
    public class PeliculaTest
    {
        private readonly ICrudService<Pelicula, Guid> _crudService;
        private Pelicula pelicula = new Pelicula
        {
            Codigo = "123124",
            GeneroId = 1,
            Nombre = "Pelicula Test",
            Descripcion = "test"

        };
        public PeliculaTest()
        {
            IRepository<Pelicula, Guid> repository = new MemoryRepository<Pelicula, Guid>();
            _crudService = new CrudService<Pelicula, Guid>(repository);
        }
        [Fact]
        public void CrearPelicula()
        {
            IRepository<Pelicula, Guid> repository = new MemoryRepository<Pelicula, Guid>();
            var crudService = new CrudService<Pelicula, Guid>(repository);
            var req = crudService.Add(pelicula);
            Assert.True(req != null && req.Id != Guid.Empty);
        }

        [Fact]
        public void EditarPelicula()
        {
            var req = _crudService.Add(pelicula);
            req.Nombre = "Otro Nombre";
            var resp = _crudService.Update(req);

            Assert.True(resp != null && resp.Id != Guid.Empty);
        }


        [Fact]
        public void EliminarPelicula()
        {
            var req = _crudService.Add(pelicula);
            _crudService.Delete(req.Id);
            Assert.True(_crudService.GetById(req.Id) ==null);
        }


        [Fact]
        public void GetPelicula()
        {            
            var cant = 10;
            for(int i=0;i<cant;i++)
                _crudService.Add(pelicula);

            Assert.True(_crudService.GetAll().Count > 0);
        }

        private void ClearDb()
        {
            _crudService.GetAll().ForEach(x => _crudService.Delete(x.Id));
        }
    }
}