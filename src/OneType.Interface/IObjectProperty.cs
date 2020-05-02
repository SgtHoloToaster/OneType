using System;
using System.Collections.Generic;
using System.Text;

namespace OneType.Interface
{
    public interface IObjectProperty
    {
        string Name { get; }

        Type Type { get; }

        object GetValue(object obj);
    }
}
