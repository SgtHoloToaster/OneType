using OneType.Interface;
using System;

namespace OneType
{
    public class DefaultObjectProperty : IObjectProperty
    {
        public Type Type { get; }

        public string Name { get; }

        public DefaultObjectProperty(Type type, string name)
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
            Equals(obj as DefaultObjectProperty);

        public bool Equals(DefaultObjectProperty property)
        {
            if (property == null)
                return false;

            if (ReferenceEquals(this, property))
                return true;

            return Equals(property.Type, Type)
                && string.Equals(property.Name, Name);
        }

        public object GetValue(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
