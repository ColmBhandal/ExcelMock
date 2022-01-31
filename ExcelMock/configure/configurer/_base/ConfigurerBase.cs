using CsharpExtras.Event.Wrapper;
using ExcelMock._base;
using ExcelMock.configure.configuration;
using ExcelMock.configure.exception;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer._base
{
    internal abstract class ConfigurerBase<TObj, TConfig, TSelf> : BaseClass,
        IConfigurer<TObj, TConfig, TSelf>
        where TSelf : IConfigurer<TObj, TConfig, TSelf>
        where TConfig : IConfiguration<TObj>
        where TObj : class
    {
        protected readonly IPreAccessWrapper<TConfig> _configurationWrapper;

        public ConfigurerBase(TConfig configuration)
        {
            _configurationWrapper = CsharpExtrasApi.NewPreAccessWrapper(
                configuration, ValidateConfigurationIsUnlocked);
        }

        private bool _locked = false;

        private TObj? _object;
        public TObj Object => _object ??= LockAndCreateObject();

        private TObj LockAndCreateObject()
        {
            TObj obj = CreateObject();
            _locked = true;
            return obj;
        }

        protected abstract TObj CreateObject();

        public TSelf WithMockSetup(Action<Mock<TObj>> setup)
        {
            _configurationWrapper.Run(c => setup(c.Mock));
            return Self;
        }

        public TSelf WithConfigSetup(Action<TConfig> setup)
        {
            _configurationWrapper.Run(setup);
            return Self;
        }
        protected abstract TSelf Self { get; }

        private void ValidateConfigurationIsUnlocked(TConfig obj)
        {
            if (_locked)
            {
                throw new ConfigurationException("Cannot configure object further: it is locked");
            }
        }
    }
}
