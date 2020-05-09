using OneType.Interface;
using System.Collections.Generic;
using System.Linq;

namespace OneType
{
    public class DefaultTypeResolver : ITypeResolver
    {
        public int GetObjectHashCode(object obj)
        {
            if (obj == null)
                return int.MinValue;

            var type = obj.GetType();
            if (type.IsPrimitive || type == typeof(string))
                return obj.GetHashCode();

            var properties = type.GetProperties();
            var hash = 17;
            unchecked
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(obj);
                    hash *= 23 + GetObjectHashCode(value);
                }
            }

            return hash;
        }

        public IEnumerable<IObjectProperty> GetProperties(object obj) =>
            obj.GetType()
                .GetProperties()
                .Select(p => new DefaultObjectProperty(p.PropertyType, p.Name))
                .ToList();

        public IObjectProperty GetProperty(object obj, string propertyName)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            return new DefaultObjectProperty(propertyInfo.PropertyType, propertyInfo.Name);
        }
    }
}
