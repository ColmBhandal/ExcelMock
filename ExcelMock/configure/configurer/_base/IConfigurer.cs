
using ExcelMock.configure.configuration;
using Moq;

namespace ExcelMock.configure.configurer._base
{
    /// <summary>
    /// A configurer is an object which manages configuring a mock object prior to its use.
    /// </summary>
    /// <typeparam name="TObj">The type of the underlying object which is being configured.</typeparam>
    /// <typeparam name="TConfig">The configuration type - which might include more raw data needed to build the mock object.</typeparam>
    /// <typeparam name="TSelf">An implementing configurer should put its own interface type in here so that method chaining can work.</typeparam>
    public interface IConfigurer<TObj, TConfig, TSelf>
        where TSelf: IConfigurer<TObj, TConfig, TSelf>
        where TConfig : IConfiguration<TObj>
        where TObj : class
    {
        /// <summary>
        /// Returns the object that's being configured. Note: once this object is accessed, it is assumed that 
        /// no further configuration will take place via this configurer. Any attempt to do so will result in an exception.
        /// </summary>
        TObj Object { get; }

        /// <summary>
        /// Runs the given action on the mock that's being used for configuring the object.
        /// </summary>
        /// <param name="setup">The action to run on the mock.</param>
        /// <returns>An instance of the configurer class- useful for method chaining.</returns>
        TSelf WithMockSetup(Action<Mock<TObj>> setup);

        /// <summary>
        /// Runs the given action on the configuration that's being used for configuring the object.
        /// </summary>
        /// <param name="setup">The action to run on the configuration.</param>
        /// <returns>An instance of the configurer class- useful for method chaining.</returns>
        TSelf WithConfigSetup(Action<TConfig> setup);
    }
}