using ExcelMock.configure.configuration.interop.worksheet;
using ExcelMock.configure.configurer.interop.worksheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.Factory
{
    internal class ConfigurerFactoryImpl : IConfigurerFactory
    {
        public IWorksheetConfigurer NewWorksheetConfigurer()
        {
            IWorksheetConfiguration configuration = new WorksheetConfigurationImpl();
            return new WorksheetConfigurerImpl(configuration);
        }
    }
}
