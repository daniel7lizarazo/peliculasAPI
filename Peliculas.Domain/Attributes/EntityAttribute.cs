using System;

namespace Peliculas.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute : Attribute
    {
        public string CollectionName { get; private set; }

        public EntityAttribute()
        {
            CollectionName = null;
        }
        public EntityAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
