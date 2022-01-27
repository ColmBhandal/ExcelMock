using ExcelMock.configure.configuration;
using ExcelMock.configure.configurer._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer.simple
{
    internal class SimpleConfigurerImpl<TObj> : ConfigurerBase<TObj, IConfiguration<TObj>>
        where TObj : class
    {

        public SimpleConfigurerImpl(IConfiguration<TObj> configuration) : base(configuration)
        {
        }

        protected override TObj CreateObject()
        {
            return _configuration.Mock.Object;
        }
    }
}
