using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Application.Interfaces;
using Peliculas.Domain.Entities;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity,TId> : ControllerBase 
        where TEntity : Entity<TId>, new()
        where TId : IComparable, IComparable<TId>

    {
        protected readonly ICrudService<TEntity,TId> _crudService;
        public BaseController(ICrudService<TEntity,TId> crudService) => _crudService = crudService;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_crudService.GetAll());
        }

        [HttpGet]
        public IActionResult GetFilter<TFilter>(TFilter filter) where TFilter : class
        {

            return Ok(_crudService.GetByFilter( x=> {
                return true;
            }));
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(TId id)
        {
            return Ok(_crudService.GetById(id));
        }


        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            return Ok(_crudService.Add(entity));
        }

        [HttpDelete]
        public virtual IActionResult Delete(TId id)
        {
            return Ok(_crudService.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(TEntity entity)
        {
            return Ok(_crudService.Update(entity));
        }
    }
}
