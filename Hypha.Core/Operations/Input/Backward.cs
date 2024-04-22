using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Input;

[Operation("1.0", OperationTypes.Input, ExecutionTypes.Backward)]
internal class Backward : IOperation<InputLayer, double[]>
{
    public string Name => throw new NotImplementedException();

    public double[] Execute(IFunction function, InputLayer t, double[] input)
    {
        throw new NotImplementedException();
    }
}
