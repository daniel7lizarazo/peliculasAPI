using Peliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Domain.Repository
{
    public interface IAlmacenarArchivos
    {
        public Task<string> EditarArchivo(byte[] contenido, string extension,string nombreContenedor,string rutaArchivo);
        public Task EliminarArchivo(string ruta, string nombreContenedor);
        public Task<string> GuardarArchivo(byte[] contenido,string extension, string contenedor);
    }
}
