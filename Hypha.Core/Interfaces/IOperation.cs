namespace Hypha.Interfaces;

internal interface IOperation
{
    string Name { get; }
}

internal interface IOperation<in T, out R> : IOperation
{
    R Execute(IFunction normalization, IFunction function, T t, double[] input);
}
