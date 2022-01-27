using ExcelMock.configure.configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer._base
{
    internal abstract class ConfigurerBase<TObj, TConfig> : IConfigurer<TObj>
        where TConfig : IConfiguration<TObj>
        where TObj : class
    {
        protected readonly IConfiguration<TObj> _configuration;

        public ConfigurerBase(IConfiguration<TObj> configuration)
        {
            _configuration = configuration;
        }

        private TObj? _object;
        public TObj Object => _object ??= CreateObject();

        protected abstract TObj CreateObject();

        public void WithMockSetup(Action<Mock<TObj>> setup)
        {

        }

    }
}
