using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMock.configure.configuration
{
    /// <summary>
    /// A configuration encapsulates the raw data for a mock object being configured.
    /// </summary>
    /// <typeparam name="TObj">The type of the object being configured.</typeparam>
    public interface IConfiguration<TObj>
        where TObj : class
    {
        /// <summary>
        /// Every configuration has a Mock object for the underlying object type.
        /// </summary>
        Mock<TObj> Mock { get; }
    }
}
