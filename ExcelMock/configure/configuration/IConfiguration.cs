using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configuration
{
    public interface IConfiguration<TObj>
        where TObj : class
    {
        Mock<TObj> Mock { get; }
    }
}
