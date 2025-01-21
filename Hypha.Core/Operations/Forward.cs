using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Functions;
using Hypha.Functions.Interfaces;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations;

[Operation("1.0", ExecutionTypes.Forward)]
internal class Forward : IOperation<Model, double[]>, IOperationOption
{
    private readonly IActivationFunction _linearTransform = new LinearTransform();

    private Dictionary<string, IActivationFunction> _activationFunc;

    public double[] Execute(IInput<Model> obj)
    {        
        foreach (var item in obj.Model.Layers)
        {
            obj.In = Calculate(item, obj.In);
        }
        return obj.In;
    }

    public void SetupOperationOptions(FunctionManager functionManager)
    {
        _activationFunc = functionManager.GetGroupFunctions<IActivationFunction>()
            .ToDictionary(k => k.GetType().Name, v => v);
    }

    private double[] Calculate(ILayer layer, double[] input)
    {
        var output = new double[layer.Neurons.Length];
        for(int i = 0; i < layer.Neurons.Length; ++i)
        {
            var linearOutput = _linearTransform.Execute(new FunctionParameters() 
            {
                SingleInput = layer.Neurons[i].Bias,
                ArrayWeight = layer.Neurons[i].Weights,
                ArrayInput = input

            });
            var activationFunction = _activationFunc[layer.ActivationFunctionName];
            var param = new FunctionParameters() { SingleInput = linearOutput.SingleOutput };
            var result = activationFunction.Execute(param);
            output[i] = result.SingleOutput.Value;
        }
        return output;
    }
}
