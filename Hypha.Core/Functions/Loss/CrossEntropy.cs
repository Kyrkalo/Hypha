using Hypha.Functions.Interfaces;

namespace Hypha.Functions.Loss;

public class CrossEntropy : IFunction, ILossFunction
{
    FunctionResult ILossFunction.Execute(FunctionParameters parameters)
    {
        int length = parameters.ArrayInput.Length;
        double[] clippedOutput = new double[length];

        for (int i = 0; i < length; i++)
        {
            clippedOutput[i] = Math.Clamp(parameters.ArrayInput[i], 1e-7, 1 - 1e-7);
        }

        double loss = 0;

        for (int i = 0; i < length; i++)
        {
            loss += parameters.ArrayTarget[i] * Math.Log(clippedOutput[i]);
        }

        return new FunctionResult() { SingleOutput = -loss };
    }
}