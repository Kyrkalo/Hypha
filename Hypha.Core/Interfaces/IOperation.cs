namespace Hypha.Interfaces;

internal interface IOperation<T, out R>
{
    R Execute(IInput<T> t);
}
