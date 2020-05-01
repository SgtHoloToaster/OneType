using OneType.Interface.Models;
using System;
using System.Collections.Generic;

namespace OneType.Interface
{
    public interface ITypeResolver
    {
        IEnumerable<ObjectProperty> GetProperties(Type type);

        object GetValue(object obj, ObjectProperty property);

        int GetHashCode(object obj);
    }
}
