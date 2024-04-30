using Hypha.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Hyperbolic tangent (tanh) is an activation function commonly used in neural networks.
/// It squashes input values between -1 and 1, providing similar behavior to the sigmoid function but centered at 0.
/// It maps any real-valued number to a value between -1 and 1.
/// As the input increases, the output of the tanh function approaches 1.
/// </summary>
internal class Tanh : IFunction
{
    public double Backward(double input)
    {
        double tanhX = Math.Tanh(input);
        return 1 - (tanhX * tanhX);
    }

    public double Activate(double value) => Math.Tanh(value);

    public void Setup(double[] inputs) { }
}
