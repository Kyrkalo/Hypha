using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Functions;
using Hypha.Functions.Interfaces;
using Hypha.Functions.Loss;
using Hypha.Interfaces;
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
    private IDerivativeFunction _errorFunction;

    private readonly IActivationFunction linearTransform = new LinearTransform();

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
        var inputs = new double[obj.Model.Layers.Count][];
        var outputs = new double[obj.Model.Layers.Count][];   
        
        Forward(obj, ref inputs, ref outputs);

        //todo: Compute Initial Error for Output Layer
        var param = new FunctionParameters { ArrayInput = outputs.LastOrDefault(), ArrayTarget = obj.Target };
        var result = _errorFunction.Execute(param);

        var errors = result.ArrayOutput;

        for (int i = obj.Model.Layers.Count - 1; i >= 0; i--)
        {
            errors = BackwardOperation(obj.Model.Layers[i], errors, _learningRate, inputs[i], outputs[i]);
        }
        return null;
    }

    /// <summary>
    /// This Forward operation returns outputs for each layer;
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private void Forward(IInput<Model> obj, ref double[][] inputs, ref double[][] outputs)
    {
        for (int i = 0; i < obj.Model.Layers.Count; ++i)
        {
            inputs[i] = obj.In;

            var layer = obj.Model.Layers[i];
            var output = new double[layer.Neurons.Length];

            for (int j = 0; j < layer.Neurons.Length; ++j)
            {
                var param = new FunctionParameters() { SingleInput = layer.Neurons[j].Bias, ArrayWeight = layer.Neurons[j].Weights, ArrayInput = obj.In };
                var result = linearTransform.Execute(param);

                param = new FunctionParameters { SingleInput = result.SingleOutput.Value };
                result = _activationFunc[layer.FunctionName].Execute(param);

                output[j] = result.SingleOutput.Value;
            }

            outputs[i] = obj.In = output;
        }
    }


    /// <summary>
    /// Layer-level operation
    /// </summary>
    /// <param name="layer"></param>
    /// <param name="errors"></param>
    /// <param name="learningRate"></param>
    /// <param name="outputs"></param>
    /// <returns></returns>
    private double[] BackwardOperation(ILayer layer, double[] errors, double learningRate, double[] inputs, double[] outputs)
    {
        //todo: Stores gradients of each neuron in this layer.
        double[] gradients = new double[layer.Neurons.Length];

        //todo: Stores gradients for the previous layer (used for backpropagation).
        double[] inputGradients = new double[layer.Neurons[0].Weights.Length];

        for (int i = 0; i < layer.Neurons.Length; i++)
        {
            var param = new FunctionParameters { SingleInput = outputs[i] };
            var gradient = errors[i] * _derivativeFunc[layer.FunctionName].Execute(param).SingleOutput.Value;
            gradients[i] = gradient;

            for (int j = 0; j < layer.Neurons[i].Weights.Length; j++)
            {
                //todo: How much each neuron's activation contributed to the error.
                inputGradients[j] += gradient * layer.Neurons[i].Weights[j];

                //todo: Update weights using gradient descent
                layer.Neurons[i].Weights[j] -= learningRate * gradient * inputs[j];
            }
            //todo: Update biase using gradient descent
            layer.Neurons[i].Bias -= learningRate * gradient;
        }

        return inputGradients;
    }
}
