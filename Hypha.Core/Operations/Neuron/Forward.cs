using Hypha.Interfaces;

namespace Hypha.Operations.Neuron;

internal class Forward : IOperation<Models.Neuron, double>
{
    public string Name => nameof(Models.Neuron);

    public double Execute(IFunction function, Models.Neuron neuron, double[] input)
    {
        double result = input.Zip(neuron.Weights, (x, w) => x * w).Sum() + neuron.Bias;
        return function.Output(result);
    }
}
