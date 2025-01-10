using Hypha.Extensions;
using Hypha.Functions;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha;

public class Hyphaflow
{
    private readonly IOperation<Model, double[]> operation;

    public Hyphaflow()
    {
        Hypha = new Model();
        operation = OperationExtensions.CreateOperation<IOperation<Model, double[]>>("1.0", Enums.ExecutionTypes.Forward);
    }

    /// <summary>
    /// Neural network model representing connections between layers and neurons
    /// </summary>
    internal Model Hypha { get; set; }

    /// <summary>
    /// Normalization function applied to the input data or intermediate layers of the model
    /// </summary>
    internal IFunction NormalizationFunction { get; set; }

    public double[] Forward(double[] input)
    {
        var result = operation.Execute(NormalizationFunction, Hypha, input);

        return result;
    }

    public double[][] Forward(double[][] input)
    {
        var result = new double[input.Length][];
        for (int i = 0; i < input.Length; i++)
        {
            result[i] = Forward(input[i]);
        }
        return result;
    }
}
