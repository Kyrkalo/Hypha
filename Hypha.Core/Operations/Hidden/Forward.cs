using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Hidden;

internal class Forward : IOperation<HiddenLayer, double[]>
{
    private readonly IOperation<Models.Neuron, double> neuronOperation;

    public Forward(IOperation<Models.Neuron, double> neuronOperation) => this.neuronOperation = neuronOperation;

    public double[] Execute(IFunction function, HiddenLayer layer, double[] input)
    {
        if (layer == null)
            return null;

        return layer.Neurons.Select(e => neuronOperation.Execute(function, e, input)).ToArray();
    }
}
