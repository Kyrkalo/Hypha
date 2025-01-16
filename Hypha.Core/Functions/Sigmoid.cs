using Hypha.Functions.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Sigmoid is a common activation function used in neural networks.
/// It squashes the input values between 0 and 1, which is useful for binary classification problems.
/// It takes any real-valued number as input and outputs a value between 0 and 1.
/// As the input increases, the output of the sigmoid function approaches 1.
/// Similarly, as the input decreases, the output approaches 0.
/// </summary>
internal class Sigmoid : IFunction, IActivationFunction, IDerivativeFunction
{
    FunctionResult IActivationFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.SingleInput == null)
        {
            throw new ArgumentException("Sigmoid activation requires a single input.");
        }

        double input = parameters.SingleInput.Value;
        double output = 1.0 / (1.0 + Math.Exp(-input));
        return new FunctionResult { SingleOutput = output };
    }

    FunctionResult IDerivativeFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.SingleInput == null)
        {
            throw new ArgumentException("Sigmoid backward requires a single output.");
        }

        double output = parameters.SingleInput.Value;
        double gradient = output * (1 - output);
        return new FunctionResult { SingleOutput = gradient };
    }
}
