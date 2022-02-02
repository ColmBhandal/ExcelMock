using CsharpExtras.Api;
using ExcelMock._base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMockTest.mock.interop.test._base
{
    public abstract class TestBase
    {        
        private ICsharpExtrasApi? _csharpExtrasApi;
        protected ICsharpExtrasApi CsharpExtrasApi => _csharpExtrasApi ??= new CsharpExtrasApi();
    }
}
