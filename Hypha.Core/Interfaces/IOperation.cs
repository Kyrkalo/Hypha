namespace Hypha.Interfaces;

internal interface IOperation
{
    string Name { get; }
}

internal interface IOperation<in T, out R> : IOperation
{
    R Execute(IFunction function, T t, double[] input);
}
