using Hypha.Models;

namespace Hypha.Operations;

internal class NeuronOperation
{
    public double Forward(Neuron neuron, double[] input)
    {
        double result = 0.0;
        for (int i = 0, j = 0; i < input.Length && j < neuron.Weights.Length; ++i, ++j)
        {
            result += input[i] * neuron.Weights[j];
        }
        return result + neuron.Bias;
    }
}
