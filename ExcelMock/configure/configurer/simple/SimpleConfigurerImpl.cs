﻿using ExcelMock.configure.configuration;
using ExcelMock.configure.configurer._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configurer.simple
{
    internal class SimpleConfigurerImpl<TObj>
        : ConfigurerBase<TObj, IConfiguration<TObj>, ISimpleConfigurer<TObj>>,
            ISimpleConfigurer<TObj>
        where TObj : class
    {

        public SimpleConfigurerImpl(IConfiguration<TObj> configuration) : base(configuration)
        {
        }

        protected override SimpleConfigurerImpl<TObj> Self => this;

        protected override TObj CreateObject()
        {
            return _configurationWrapper.Get(c => c.Mock.Object);
        }
    }
}
