using ExcelMock.build.builder._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.build.builder.simple
{
    /// <summary>
    /// A simple builder is a builder without any extra methods beyond the base builder type.
    /// </summary>
    /// <typeparam name="TObj">The type of the object being built.</typeparam>
    public interface ISimpleBuilder<TObj>: IBuilder<TObj, ISimpleBuilder<TObj>>
        where TObj : class
    {
    }
}
