using Hypha.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// ReLU (Rectified Linear Unit) is a popular activation function used in neural networks.
/// It introduces non-linearity by returning 0 for negative inputs and leaving positive inputs unchanged.
/// If the input is greater than 0, ReLU returns the input value. If the input is negative, ReLU returns 0.
/// </summary>
internal class ReLU : IFunction
{
    public double Backward(double input)
    {
        return input > 0 ? 1 : 0;
    }

    public double Activate(double value) => Math.Max(0, value);

    public void Setup(double[] inputs) { }
}
