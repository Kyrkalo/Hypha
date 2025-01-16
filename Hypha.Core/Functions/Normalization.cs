using Hypha.Functions.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Normalization is a process of scaling data to a common range or distribution.
/// This normalization function scales input values to a range between 0 and 1.
/// It subtracts the minimum value from each input value and then divides by the range (max - min).
/// This ensures that all input values fall within the 0 to 1 range.
/// </summary>
internal class Normalization : IFunction, IActivationFunction, IDerivativeFunction
{
    FunctionResult IActivationFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.SingleInput == null)
        {
            throw new ArgumentException("Normalization requires a single input.");
        }
        double input = parameters.SingleInput.Value;
        double min = parameters.ArrayInput.Min();
        double max = parameters.ArrayInput.Max();

        double output = max == 0 || min == 0 ? 0 : (input - min) / (max - min);

        return new FunctionResult { SingleOutput = output };
    }

    FunctionResult IDerivativeFunction.Execute(FunctionParameters parameters)
    {
        double min = parameters.ArrayInput.Min();
        double max = parameters.ArrayInput.Max();

        double derivative = 1 / (max - min);

        return new FunctionResult { SingleOutput = derivative };
    }
}
