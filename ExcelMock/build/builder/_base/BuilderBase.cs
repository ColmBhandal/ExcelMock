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

        private readonly IList<Action<Mock<TObj>>> _setupActions =
            new List<Action<Mock<TObj>>>();

        public BuilderBase()
        {
        }

        public TObj Build()
        {
            Mock<TObj> mock = new Mock<TObj>();
            foreach (Action<Mock<TObj>> action in _setupActions)
            {
                //action(mock);
            }
            return mock.Object;
        }

        public TSelf WithMockSetup(Action<Mock<TObj>> setup)
        {
            _setupActions.Add(setup);
            return Self;
        }
        protected abstract TSelf Self { get; }
    }
}
