using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Hidden;

[Operation("1.0", OperationTypes.Hidden, ExecutionTypes.Forward)]
internal class Forward : IOperation<HiddenLayer, double[]>
{
    private readonly IOperation<Models.Neuron, double> neuronOperation;

    public Forward(IOperation<Models.Neuron, double> neuronOperation) => this.neuronOperation = neuronOperation;

    public string Name => nameof(HiddenLayer);

    public double[] Execute(IFunction function, HiddenLayer layer, double[] input)
    {
        if (layer == null)
            return null;

        return layer.Neurons.Select(e => neuronOperation.Execute(function, e, input)).ToArray();
    }
}
