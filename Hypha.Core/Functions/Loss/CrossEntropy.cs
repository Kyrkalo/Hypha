using Hypha.Interfaces;

namespace Hypha.Functions.Loss;

public class CrossEntropy : ILoss
{
    public double Execute(double[] output, double[] target)
    {
        int length = output.Length;
        double[] clippedOutput = new double[length];

        for (int i = 0; i < length; i++)
        {
            clippedOutput[i] = Math.Clamp(output[i], 1e-7, 1 - 1e-7);
        }

        double loss = 0;

        for (int i = 0; i < length; i++)
        {
            loss += target[i] * Math.Log(clippedOutput[i]);
        }

        return -loss;
    }
}