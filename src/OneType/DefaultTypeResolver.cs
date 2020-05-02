using OneType.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneType
{
    public class DefaultTypeResolver : ITypeResolver
    {
        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
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
