using Hypha.Interfaces;

namespace Hypha.Functions;

public class CrossEntropy : ILoss
{
    public double[] Forward(double[][] prediction, object target)
    {
        int samples = prediction.Length;

        double[][] yPredClipped = ClipPredictions(prediction);

        double[] correctConfidence = new double[samples];

        if (target is int[] yTrueSparse)
        {
            for (int i = 0; i < samples; i++)
            {
                correctConfidence[i] = yPredClipped[i][yTrueSparse[i]];
            }
        }
        else if (target is int[][] yTrueOneHot)
        {
            for (int i = 0; i < samples; i++)
            {
                correctConfidence[i] = yPredClipped[i]
                    .Zip(yTrueOneHot[i], (pred, trueVal) => pred * trueVal)
                    .Sum();
            }
        }
        else
        {
            throw new ArgumentException("yTrue must be either int[] (sparse labels) or double[][] (one-hot encoded labels).");
        }

        return correctConfidence.Select(conf => -Math.Log(conf)).ToArray();
    }

    /// <summary>
    /// Need this method to prevent log(0)
    /// </summary>
    /// <param name="yPred"></param>
    /// <returns></returns>
    private double[][] ClipPredictions(double[][] yPred)
    {
        double[][] yPredClipped = new double[yPred.Length][];

        for (int i = 0; i < yPred.Length; i++)
        {
            yPredClipped[i] = new double[yPred[i].Length];
            for (int j = 0; j < yPred[i].Length; j++)
            {
                yPredClipped[i][j] = Math.Clamp(yPred[i][j], 1e-7, 1 - 1e-7);
            }
        }
        return yPredClipped;
    }
}