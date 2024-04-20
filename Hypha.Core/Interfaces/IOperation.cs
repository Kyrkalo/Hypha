namespace Hypha.Interfaces;

internal interface IOperation<in T, out R>
{
    R Execute(IFunction function, T t, double[] input);
}
