using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;

namespace Hypha.Operations.Neuron;

[Operation("1.0", OperationTypes.Neuron, ExecutionTypes.Backward)]
internal class Backward : IOperation<Models.Neuron, double>
{
    public string Name => throw new NotImplementedException();

    public double Execute(IFunction function, Models.Neuron t, double[] input)
    {
        throw new NotImplementedException();
    }
}
