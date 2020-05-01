using System;

namespace OneType.Interface.Models
{
    public class ObjectProperty
    {
        public Type Type { get; set; }

        public string Name { get; set; }

        public ObjectProperty(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
