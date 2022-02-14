using CsharpExtras.Event.Wrapper;
using ExcelMock._base;
using ExcelMock.build.exception;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.build.builder._base
{
    internal abstract class BuilderBase<TObj, TSelf> : BaseClass, IBuilder<TObj, TSelf>
        where TSelf : IBuilder<TObj, TSelf>
        where TObj : class
    {

        public BuilderBase()
        {
        }

        public TObj Build()
        {
            //TODO: Implement properly
            return new Mock<TObj>().Object;
        }

        public TSelf WithMockSetup(Action<Mock<TObj>> setup)
        {
            return Self;
        }
        protected abstract TSelf Self { get; }
    }
}
