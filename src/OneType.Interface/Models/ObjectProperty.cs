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

        public override int GetHashCode()
        {
            var hash = 17;
            unchecked
            {
                hash *= 23 + (Type?.GetHashCode() ?? 0);
                hash *= 23 + (Name?.GetHashCode() ?? 0);
            }

            return hash;
        }

        public override bool Equals(object obj) =>
            Equals(obj as ObjectProperty);

        public bool Equals(ObjectProperty property)
        {
            if (property == null)
                return false;

            if (ReferenceEquals(this, property))
                return true;

            return Equals(property.Type, Type)
                && string.Equals(property.Name, Name);
        }
    }
}
