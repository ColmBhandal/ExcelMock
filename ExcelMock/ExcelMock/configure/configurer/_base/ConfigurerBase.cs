using ExcelMock.configure.configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer._base
{
    internal abstract class ConfigurerBase<TObj, TConfig, TSelf> : IConfigurer<TObj, TConfig, TSelf>
        where TSelf : IConfigurer<TObj, TConfig, TSelf>
        where TConfig : IConfiguration<TObj>
        where TObj : class
    {
        protected readonly TConfig _configuration;

        public ConfigurerBase(TConfig configuration)
        {
            _configuration = configuration;
        }

        private TObj? _object;
        public TObj Object => _object ??= CreateObject();

        protected abstract TObj CreateObject();

        public TSelf WithMockSetup(Action<Mock<TObj>> setup)
        {
            return Self;
        }

        public TSelf WithConfigSetup(Action<TConfig> setup)
        {
            return Self;
        }
        protected abstract TSelf Self { get; }
    }
}
