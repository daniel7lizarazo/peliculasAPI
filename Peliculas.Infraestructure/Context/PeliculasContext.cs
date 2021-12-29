using Microsoft.EntityFrameworkCore;
using Peliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Context
{
    public class PeliculasContext: DbContext
    {
        private static long InstanceCount;

        public PeliculasContext(DbContextOptions<PeliculasContext> options) : base(options)
            => Interlocked.Increment(ref InstanceCount);

        public DbSet<Pelicula> Peliculas { set; get; }
        public DbSet<ImagenPelicula> ImagenesPeliculas { set; get; }
    }
}
