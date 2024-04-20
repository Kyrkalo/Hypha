using Hypha.Interfaces;

namespace Hypha.Operations.Neuron;

internal class Forward : IOperation<Models.Neuron, double>
{
    public double Execute(IFunction function, Models.Neuron neuron, double[] input)
    {
        double result = 0.0;
        for (int i = 0, j = 0; i < input.Length && j < neuron.Weights.Length; ++i, ++j)
        {
            result += input[i] * neuron.Weights[j];
        }
        return result + neuron.Bias;
    }
}
