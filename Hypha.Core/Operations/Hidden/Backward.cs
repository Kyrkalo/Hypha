using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Hidden;

[Operation("1.0", OperationTypes.Hidden, ExecutionTypes.Backward)]
internal class Backward : IOperation<HiddenLayer, double[]>
{
    public string Name => throw new NotImplementedException();

    public double[] Execute(IFunction function, HiddenLayer t, double[] input)
    {
        throw new NotImplementedException();
    }
}
