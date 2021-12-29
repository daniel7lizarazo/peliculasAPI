using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas.Domain.Entities
{
    public abstract class Entity<TId> where TId : IComparable, IComparable<TId>
    {
       public TId Id { get; set; }
    }
}
