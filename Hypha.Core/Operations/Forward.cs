using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Functions;
using Hypha.Interfaces;
using Hypha.LinearAlgebra;
using Hypha.Models;

namespace Hypha.Operations;

[Operation("1.0", ExecutionTypes.Forward)]
internal class Forward : IOperation<Model, double[]>
{
    private readonly IFunction linearTransform;

    public Forward()
    {
        linearTransform = new LinearTransform();
    }

    public double[] Execute(IInput<Model> obj)
    {        
        foreach (var item in obj.Model.Layers)
        {
            obj.In = Calculate(item, obj.In);
        }
        return obj.In;
    }

    private double[] Calculate(ILayer layer, double[] input)
    {
        var output = new double[layer.Neurons.Length];
        for(int i = 0; i < layer.Neurons.Length; ++i)
        {
            var linearOutput = linearTransform.Activate(new FunctionParameters() 
            {
                SingleInput = layer.Neurons[i].Bias,
                ArrayWeight = layer.Neurons[i].Weights,
                ArrayInput = input

            });
            var result = layer.Activate(new FunctionParameters() { SingleInput = linearOutput.SingleOutput });
            output[i] = result.SingleOutput.Value;
        }
        return output;
    }
}
