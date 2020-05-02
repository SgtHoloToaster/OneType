using OneType.Interface.Models;
using System;
using System.Collections.Generic;

namespace OneType.Interface
{
    public interface ITypeResolver
    {
        IObjectProperty GetProperty(object obj, string propertyName);

        IEnumerable<IObjectProperty> GetProperties(object obj);

        int GetHashCode(object obj);
    }
}
