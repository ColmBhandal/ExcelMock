using ExcelMock.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock
{
    /// <summary>
    /// Entry point for all types within the ExcelMock library.
    /// </summary>
    public class ExcelMockApi : IExcelMockApi
    {
        private IBuilderFactory? builderFactory;

        /// <summary>
        /// The builder factory allows for the creation of new builders.
        /// See <see cref="IBuilderFactory"/>
        /// </summary>
        public IBuilderFactory BuilderFactory =>
            builderFactory ??= new BuilderFactoryImpl();
    }
}
