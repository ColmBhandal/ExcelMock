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
        private IConfigurerFactory? configurerFactory;

        /// <summary>
        /// The configurer factory allows for the creation of new configurers.
        /// See <see cref="IConfigurerFactory"/>
        /// </summary>
        public IConfigurerFactory ConfigurerFactory =>
            configurerFactory ??= new ConfigurerFactoryImpl();
    }
}
