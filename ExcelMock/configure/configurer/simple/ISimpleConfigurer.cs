using ExcelMock.configure.configuration;
using ExcelMock.configure.configurer._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer.simple
{
    /// <summary>
    /// A simple configurer is a configurer without any extra methods beyond the base configurer type.
    /// </summary>
    /// <typeparam name="TObj">The type of the object being configured.</typeparam>
    public interface ISimpleConfigurer<TObj>: IConfigurer<TObj, IConfiguration<TObj>, ISimpleConfigurer<TObj>>
        where TObj : class
    {
    }
}
