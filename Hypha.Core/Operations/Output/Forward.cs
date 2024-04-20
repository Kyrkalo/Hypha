using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Output;

internal class Forward : IOperation<OutputLayer, double[]>
{
    private readonly IOperation<Models.Neuron, double> neuronOperation;

    public Forward(IOperation<Models.Neuron, double> neuronOperation) => this.neuronOperation = neuronOperation;

    public double[] Execute(IFunction function, OutputLayer layer, double[] input)
    {
        if (layer == null)
            return null;

        return layer.Outputs.Select(e => neuronOperation.Execute(function, e, input)).ToArray();
    }
}
