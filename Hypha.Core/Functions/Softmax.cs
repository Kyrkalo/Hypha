using Hypha.Functions.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// The Softmax function is typically used in the output layer of a 
/// neural network for classification tasks. It converts raw scores (logits) 
/// into probabilities, ensuring the sum of probabilities equals 1.
/// </summary>
internal class Softmax : IFunction, IActivationFunction, IDerivativeFunction
{
    FunctionResult IActivationFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.ArrayInput == null)
        {
            throw new ArgumentException("Softmax activation requires an array input.");
        }

        double[] input = parameters.ArrayInput;
        double max = input.Max();
        double[] expValues = input.Select(x => Math.Exp(x - max)).ToArray();
        double sumExpValues = expValues.Sum();
        double[] probabilities = expValues.Select(x => x / sumExpValues).ToArray();

        return new FunctionResult { ArrayOutput = probabilities };
    }

    FunctionResult IDerivativeFunction.Execute(FunctionParameters parameters)
    {
        if (parameters.ArrayInput == null || parameters.ArrayTarget == null)
        {
            throw new ArgumentException("Softmax backward requires array input and target.");
        }

        double[] predictions = parameters.ArrayInput;
        double[] targets = parameters.ArrayTarget;

        if (predictions.Length != targets.Length)
        {
            throw new ArgumentException("Predictions and targets must have the same length.");
        }

        double[] gradients = predictions.Zip(targets, (yPred, yTrue) => yPred - yTrue).ToArray();
        return new FunctionResult { ArrayOutput = gradients };
    }
}
