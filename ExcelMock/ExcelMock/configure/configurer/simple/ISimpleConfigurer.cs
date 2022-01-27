using ExcelMock.configure.configuration;
using ExcelMock.configure.configurer._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer.simple
{
    public interface ISimpleConfigurer<TObj>: IConfigurer<TObj, IConfiguration<TObj>, ISimpleConfigurer<TObj>>
        where TObj : class
    {
    }
}
