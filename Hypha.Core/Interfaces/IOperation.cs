namespace Hypha.Interfaces;

internal interface IOperation
{
    string Name { get; }
}

internal interface IOperation<T, out R> : IOperation
{
    R Execute(IInput<T> t);
}
