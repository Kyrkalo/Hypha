using Hypha.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Sigmoid is a common activation function used in neural networks.
/// It squashes the input values between 0 and 1, which is useful for binary classification problems.
/// It takes any real-valued number as input and outputs a value between 0 and 1.
/// As the input increases, the output of the sigmoid function approaches 1.
/// Similarly, as the input decreases, the output approaches 0.
/// </summary>
internal class Sigmoid : IFunction
{
    public double Backward(double input)
    {
        double sigmoidX = Activate(input);
        return sigmoidX * (1 - sigmoidX);
    }

    public double Activate(double value) => 1 / (1 + Math.Exp(-value));

    public void Setup(double[] inputs) { }
}
