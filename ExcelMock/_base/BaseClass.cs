using CsharpExtras.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock._base
{
    internal class BaseClass
    {
        private ICsharpExtrasApi? _csharpExtrasApi;
        protected ICsharpExtrasApi CsharpExtrasApi => _csharpExtrasApi ??= new CsharpExtrasApi();
    }
}
