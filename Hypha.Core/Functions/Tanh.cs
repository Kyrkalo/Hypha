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
    public double Derivative(double input)
    {
        double tanhX = Math.Tanh(input);
        return 1 - (tanhX * tanhX);
    }

    public double Activate(double value) => Math.Tanh(value);

    public void Setup(double[] inputs) { }

    public FunctionResult Activate(FunctionParameters parameters)
    {
        if (parameters.SingleInput.HasValue)
        {
            double activated = Math.Tanh(parameters.SingleInput.Value);
            return new FunctionResult { SingleOutput = activated };
        }
        else if (parameters.ArrayInput != null)
        {
            double[] activatedArray = parameters.ArrayInput.Select(Math.Tanh).ToArray();
            return new FunctionResult { ArrayOutput = activatedArray };
        }
        throw new ArgumentException("Invalid parameters for Tanh activation.");
    }

    public FunctionResult Derivative(FunctionParameters parameters)
    {
        if (parameters.SingleInput.HasValue)
        {
            double tanhValue = Math.Tanh(parameters.SingleInput.Value);
            double gradient = 1 - Math.Pow(tanhValue, 2);
            return new FunctionResult { SingleOutput = gradient };
        }
        else if (parameters.ArrayInput != null)
        {
            double[] gradients = parameters.ArrayInput
                .Select(x => 1 - Math.Pow(Math.Tanh(x), 2))
                .ToArray();
            return new FunctionResult { ArrayOutput = gradients };
        }
        throw new ArgumentException("Invalid parameters for Tanh backward.");
    }
}
