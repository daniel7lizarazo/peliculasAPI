using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas.Application.DTOs
{
    public class ImagenPeliculaDTO
    {
        public Guid PeliculaId { get; set; }
        public byte[] ImagenBase64 { get; set; }
        public string Nombre { get; set;}
        public string Extension { get; set;}
    }
}
