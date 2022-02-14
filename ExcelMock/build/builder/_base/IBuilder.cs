using Moq;

namespace ExcelMock.build.builder._base
{
    /// <summary>
    /// A builder is an object which manages building a mock object prior to its use.
    /// </summary>
    /// <typeparam name="TObj">The type of the underlying object which is being built.</typeparam>
    /// <typeparam name="TSelf">An implementing builder should put its own interface type in here so that method chaining can work.</typeparam>
    public interface IBuilder<TObj, TSelf>
        where TSelf: IBuilder<TObj, TSelf>        
        where TObj : class
    {        
        /// <summary>
        /// Builds a new mock object.
        /// </summary>
        /// <returns>A new mock object.</returns>
        TObj Build();

        /// <summary>
        /// Runs the given action on the mock that's being used for building the object.
        /// </summary>
        /// <param name="setup">The action to run on the mock.</param>
        /// <returns>An instance of the builder class- useful for method chaining.</returns>
        TSelf WithMockSetup(Action<Mock<TObj>> setup);
    }
}