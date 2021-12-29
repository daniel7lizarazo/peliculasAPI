using Peliculas.Application.Utils;
using Peliculas.Domain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure
{
    public class AlmacenadorArchivosLocal : IAlmacenarArchivos
    {
        private readonly string path;
        private readonly string host;
        public AlmacenadorArchivosLocal()
        {
            host = AppVariables.RootPath;
            path = AppVariables.WebRootPath;
        }
        public async Task<string> EditarArchivo(byte[] contenido, string extension, string nombreContenedor,string rutaArchivo)
        {
            if (!string.IsNullOrEmpty(rutaArchivo)) 
            {
                await EliminarArchivo(rutaArchivo, nombreContenedor);
            }
            return await GuardarArchivo(contenido, extension, nombreContenedor);
        }

        public Task EliminarArchivo(string ruta, string nombreContenedor)
        {
            var fileName = Path.GetFileName(ruta);
            string directorioArchivo = Path.Combine(path, nombreContenedor, fileName);
            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }
            return Task.FromResult(0);
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor)
        {
            string fileName = $"{Guid.NewGuid()}.{extension}";
            string folder = Path.Combine(path, nombreContenedor);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string rutaGuardado = Path.Combine(folder, fileName);
            await File.WriteAllBytesAsync(rutaGuardado, contenido);
            var url = $"{host}/{nombreContenedor}/{fileName}";
            return url;
        }
    }
}
