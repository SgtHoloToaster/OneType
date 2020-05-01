using OneType.Interface;
using OneType.Interface.Models;
using System;
using System.Collections.Generic;

namespace OneType
{
    public class DefaultTypeResolver : ITypeResolver
    {
        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjectProperty> GetProperties(Type type)
        {
            throw new NotImplementedException();
        }

        public object GetValue(object obj, ObjectProperty property)
        {
            throw new NotImplementedException();
        }
    }
}
