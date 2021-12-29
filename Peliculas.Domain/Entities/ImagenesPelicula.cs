using System;
using System.Collections.Generic;
using System.Text;
using Peliculas.Domain.Attributes;

namespace Peliculas.Domain.Entities
{
    [Entity]
    public  class ImagenPelicula : Entity<Guid>
    {
        public string Nombre { get; set; }
        public string Path { get; set; }
        public Guid PeliculaId { get; set; }
    }
}
