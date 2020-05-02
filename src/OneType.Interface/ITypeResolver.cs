using OneType.Interface.Models;
using System;
using System.Collections.Generic;

namespace OneType.Interface
{
    public interface ITypeResolver
    {
        ObjectProperty GetProperty(object obj, string propertyName);

        IEnumerable<ObjectProperty> GetProperties(object obj);

        object GetValue(object obj, ObjectProperty property);

        object GetValue(object obj, string propertyPath);

        int GetHashCode(object obj);
    }
}
