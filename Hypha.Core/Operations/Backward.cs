using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.LinearAlgebra;
using Hypha.Models;

namespace Hypha.Operations;

[Operation("1.0", ExecutionTypes.Backward)]
internal class Backward : IOperation<Model, double[]>, IOperationOption
{
    /// <summary>
    /// learning rate
    /// </summary>
    private double _learningRate;

    /// <summary>
    /// Function tocalculate error loss 
    /// </summary>
    private IFunction _errorFunction;

    public void SetupOperationOptions(Option options)
    {
        _errorFunction = options.ErrorFunction;
        _learningRate = options.LearningRate;
    }

    public double[] Execute(IInput<Model> obj)
    {
        var outputs = Forward(obj);
        var param = new FunctionParameters { ArrayInput = obj.In, ArrayTarget = obj.Target };
        var functionResult = _errorFunction.Derivative(param);
        var errors = functionResult.ArrayOutput;
        for (int i = obj.Model.Layers.Count - 1; i >= 0; i--)
        {
            errors = BackwardOperation(obj.Model.Layers[i], errors, _learningRate, outputs[i]);
        }
        return null;
    }

    /// <summary>
    /// This Forward operation returns outputs for each layer;
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private double[][] Forward(IInput<Model> obj)
    {
        double[][] outputs = new double[obj.Model.Layers.Count][];
        for (int i = 0; i < obj.Model.Layers.Count; ++i)
        {
            var layer = obj.Model.Layers[i];
            var output = new double[layer.Neurons.Length];

            for (int j = 0; j < layer.Neurons.Length; ++j)
            {
                var weights = layer.Neurons[j].Weights;
                output[j] = weights.Dot(obj.In) + layer.Neurons[j].Bias;
                var result = layer.Activate(new FunctionParameters { SingleInput = output[j] });
                output[j] = result.SingleOutput.Value;
            }
            outputs[i] = output;
        }
        return outputs;
    }

    public double[] BackwardOperation(ILayer layer, double[] errors, double learningRate, double[] outputs)
    {
        double[] gradients = new double[layer.Neurons.Length];
        double[] inputGradients = new double[layer.Neurons[0].Weights.Length];

        for (int i = 0; i < layer.Neurons.Length; i++)
        {
            var result = layer.Derivative(new FunctionParameters { SingleInput = outputs[i] });

            gradients[i] = errors[i] * result.SingleOutput.Value;

            for (int j = 0; j < layer.Neurons[i].Weights.Length; j++)
            {
                inputGradients[j] += gradients[i] * layer.Neurons[i].Weights[j];
                layer.Neurons[i].Weights[j] -= learningRate * gradients[i] * outputs[j];
            }
            layer.Neurons[i].Bias -= learningRate * gradients[i];
        }

        return inputGradients;
    }
}
