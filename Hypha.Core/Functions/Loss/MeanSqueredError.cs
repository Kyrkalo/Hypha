using Hypha.Functions.Interfaces;

namespace Hypha.Functions.Loss;

/// <summary>
/// Loss function: Mean Squared Error (MSE)
/// </summary>
internal class MeanSqueredError : IFunction, ILossFunction, IDerivativeFunction
{
    FunctionResult ILossFunction.Execute(FunctionParameters parameters)
    {
        var output = parameters.ArrayInput;
        var target = parameters.ArrayTarget;

        double loss = 0;
        for (int i = 0; i < output.Length; i++)
        {
            loss += Math.Pow(output[i] - target[i], 2);
        }
        loss /= output.Length;
        return new FunctionResult(loss);
    }

    FunctionResult IDerivativeFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.ArrayInput == null || parameters.Input3 == null)
            throw new ArgumentException("Both predicted and target values must be provided.");

        double[] predicted = parameters.ArrayInput;
        double[] target = parameters.ArrayTarget;

        int n = predicted.Length;

        double[] gradient = new double[predicted.Length];
        for (int i = 0; i < predicted.Length; i++)
        {
            gradient[i] = 2.0 / n * (predicted[i] - target[i]);
        }

        return new FunctionResult(ArrayOutput: gradient);
    }
}
