using OneType.Interface.Models;
using System;
using System.Collections.Generic;

namespace OneType.Interface
{
    public interface ITypeResolver
    {
        IEnumerable<ObjectProperty> GetProperties(object obj);

        object GetValue(object obj, ObjectProperty property);

        int GetHashCode(object obj);
    }
}
