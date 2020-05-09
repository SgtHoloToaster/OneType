using System.Collections.Generic;

namespace OneType.Interface
{
    public interface ITypeResolver
    {
        IObjectProperty GetProperty(object obj, string propertyName);

        IEnumerable<IObjectProperty> GetProperties(object obj);

        // TODO: maybe move it to a separate universal equalityComparer
        int GetObjectHashCode(object obj);
    }
}
