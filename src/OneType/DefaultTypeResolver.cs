using OneType.Interface;
using OneType.Interface.Models;
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

        public IEnumerable<ObjectProperty> GetProperties(object obj) =>
            obj.GetType()
                .GetProperties()
                .Select(p => new ObjectProperty(p.PropertyType, p.Name))
                .ToList();

        public object GetValue(object obj, ObjectProperty property)
        {
            throw new NotImplementedException();
        }

        public object GetValue(object obj, string propertyPath)
        {
            return obj.GetType()
                .GetProperty(propertyPath)
                .GetValue(obj);
        }
    }
}
