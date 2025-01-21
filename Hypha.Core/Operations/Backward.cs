using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Functions;
using Hypha.Functions.Interfaces;
using Hypha.Functions.Loss;
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
    private double _learningRate = 0.05;

    /// <summary>
    /// Function tocalculate error loss 
    /// </summary>
    private ILossFunction _errorFunction;

    private IActivationFunction linearTransform = new LinearTransform();

    private Dictionary<string, IActivationFunction> _activationFunc;

    private Dictionary<string, IDerivativeFunction> _derivativeFunc;

    public void SetupOperationOptions(FunctionManager functionManager)
    {
        _errorFunction = functionManager.GetGroupFunctions<MeanSqueredError>().FirstOrDefault();
        _activationFunc = functionManager.GetGroupFunctions<IActivationFunction>().ToDictionary(k => k.GetType().Name, v => v);
        _derivativeFunc = functionManager.GetGroupFunctions<IDerivativeFunction>().ToDictionary(k => k.GetType().Name, v => v);
    }

    public double[] Execute(IInput<Model> obj)
    {
        var outputs = Forward(obj);
        var param = new FunctionParameters { ArrayInput = obj.In, ArrayTarget = obj.Target };
        var functionResult = _errorFunction.Execute(param);
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
                var neuron = layer.Neurons[j];
                var linearOutput = linearTransform.Execute(new FunctionParameters()
                { 
                    SingleInput = neuron.Bias, ArrayWeight = neuron.Weights, ArrayInput = obj.In 
                });
                var activationHash = _activationFunc[layer.ActivationFunctionName];
                var param = new FunctionParameters { SingleInput = linearOutput.SingleOutput.Value };
                var result = activationHash.Execute(param);
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
            var param = new FunctionParameters { SingleInput = outputs[i] };
            var derivative  = _derivativeFunc[layer.DerivativeFunctionName];
            var result = derivative.Execute(param);

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
