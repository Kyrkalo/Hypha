using Hypha.Interfaces;
using Hypha.LinearAlgebra;

namespace Hypha.Functions;

/// <summary>
/// The Softmax function is typically used in the output layer of a 
/// neural network for classification tasks. It converts raw scores (logits) 
/// into probabilities, ensuring the sum of probabilities equals 1.
/// </summary>
internal class Softmax : IFunction
{
    public double Activate(double value) => value;

    public double Backward(double input)
    {
        throw new NotImplementedException();
    }

    public void Setup(double[] inputs)
    {
        var max = inputs.Max();

        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = Math.Exp(inputs[i] - max);
        }

        var sum = inputs.Sum();

        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = inputs[i] / sum;
        }
    }
}
