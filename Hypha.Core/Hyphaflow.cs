using Hypha.Extensions;
using Hypha.Functions;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha;

public class Hyphaflow
{
    private readonly IOperation<Model, double[]> forwardOperation;
    private readonly IOperation<Model, double[]> backwardOperation;
    private readonly FunctionManager functionManager;

    public Hyphaflow()
    {
        Hypha = new Model();
        functionManager = new FunctionManager();
        forwardOperation = OperationExtensions.CreateOperation<IOperation<Model, double[]>>("1.0", Enums.ExecutionTypes.Forward);
        backwardOperation = OperationExtensions.CreateOperation<IOperation<Model, double[]>>("1.0", Enums.ExecutionTypes.Backward);
        SetFunctionReferences(forwardOperation);
        SetFunctionReferences(backwardOperation);
    }

    /// <summary>
    /// Neural network model representing connections between layers and neurons
    /// </summary>
    internal Model Hypha { get; set; }

    public double[] Forward(double[] input)
    {
        var forwardInput = new Input()
        {
            Model = Hypha,
            In = input
        };
        return forwardOperation.Execute(forwardInput);
    }

    public void Train(double[][] input, double[][] target, int steps)
    {
        //for (int epoch = 0; epoch < epochs; epoch++)
        //{
        //    double totalLoss = 0;

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        double[] output = forwardOperation.Execute(Hypha, input[i]);

        //        totalLoss += CalculateLoss(output, target[i]);

        //        // Backward pass
        //        backwardOperation.Execute(input[i], target[i], output);
        //    }

        //    if (epoch % 100 == 0)
        //    {
        //        Console.WriteLine($"Epoch {epoch}/{epochs}, Loss: {totalLoss / input.Length}");
        //    }
        //}
        for (int s = 0; s < steps; s++)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Backward(input[i], target[i]);
            }
        }
    }

    private void Backward(double[] input, double[] target)
    {
        var inputData = new Input()
        {
            Model = Hypha,
            In = input,
            Target = target,
        };
        backwardOperation.Execute(inputData);
    }

    private void SetFunctionReferences(object operation)
    {
        if (operation != null && operation is IOperationOption operationOption)
        {
            operationOption.SetupOperationOptions(functionManager);
        }
    }
}
