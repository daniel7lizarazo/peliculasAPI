using System;
using Peliculas.Domain.Attributes;

namespace Peliculas.Domain.Entities
{
    [Entity]
    public  class Pelicula : Entity<Guid>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int GeneroId { get; set; }
    }
}
