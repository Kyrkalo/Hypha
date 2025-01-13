using Hypha.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// ReLU (Rectified Linear Unit) is a popular activation function used in neural networks.
/// It introduces non-linearity by returning 0 for negative inputs and leaving positive inputs unchanged.
/// If the input is greater than 0, ReLU returns the input value. If the input is negative, ReLU returns 0.
/// </summary>
internal class ReLU : IFunction
{
    public FunctionResult Activate(FunctionParameters parameters)
    {
        if (parameters.SingleInput.HasValue)
        {
            double activated = Math.Max(0, parameters.SingleInput.Value);
            return new FunctionResult { SingleOutput = activated };
        }
        else if (parameters.ArrayInput != null)
        {
            double[] activatedArray = parameters.ArrayInput.Select(x => Math.Max(0, x)).ToArray();
            return new FunctionResult { ArrayOutput = activatedArray };
        }
        throw new ArgumentException("Invalid parameters for ReLU activation.");
    }

    public FunctionResult Derivative(FunctionParameters parameters)
    {
        if (parameters.SingleInput.HasValue)
        {
            double gradient = parameters.SingleInput.Value > 0 ? 1.0 : 0.0;
            return new FunctionResult { SingleOutput = gradient };
        }
        else if (parameters.ArrayInput != null)
        {
            double[] gradients = parameters.ArrayInput.Select(x => x > 0 ? 1.0 : 0.0).ToArray();
            return new FunctionResult { ArrayOutput = gradients };
        }
        throw new ArgumentException("Invalid parameters for ReLU backward.");
    }
}
