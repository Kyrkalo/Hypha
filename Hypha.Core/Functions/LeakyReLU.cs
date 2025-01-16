using Hypha.Functions.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Leaky ReLU (Rectified Linear Unit) is an activation function used in neural networks.
/// It is similar to the ReLU function but allows a small, non-zero gradient when the input is negative.
/// This helps prevent the "dying ReLU" problem where neurons can become inactive during training.
/// The function returns x if x is positive and a small fraction (usually a constant like 0.01) of x if x is negative.
/// Leaky ReLU(x) = x if x >= 0, else alpha * x where alpha is a small positive constant. 
/// </summary>
internal class LeakyReLU : IFunction, IActivationFunction, IDerivativeFunction
{
    private double alpha = 0.01;  // Leak factor (default 0.01)

    FunctionResult IActivationFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.SingleInput != null)
        {
            return new(SingleOutput: parameters.SingleInput.Value < 0 ? alpha * parameters.SingleInput.Value : parameters.SingleInput.Value);
        }
        else if (parameters.ArrayInput != null)
        {
            return new(ArrayOutput: parameters.ArrayInput.Select(e => e > 0 ? e : alpha * e).ToArray());
        }
        else
        {
            throw new ArgumentException("Invalid input parameters.");
        }
    }

    FunctionResult IDerivativeFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.SingleInput != null)
        {
            var result = parameters.SingleInput.Value > 0 ? 1 : alpha;
            return new FunctionResult(SingleOutput: result);
        }
        else if (parameters.ArrayInput != null)
        {
            var result = parameters.ArrayInput.Select(x => x > 0 ? 1 : alpha).ToArray();
            return new FunctionResult(ArrayOutput: result);
        }
        else
        {
            throw new ArgumentException("Invalid input parameters.");
        }
    }
}
