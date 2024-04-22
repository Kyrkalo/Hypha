using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Output;

[Operation("1.0", OperationTypes.Output, ExecutionTypes.Backward)]
internal class Backward : IOperation<OutputLayer, double[]>
{
    public string Name => throw new NotImplementedException();

    public double[] Execute(IFunction function, OutputLayer t, double[] input)
    {
        throw new NotImplementedException();
    }
}
