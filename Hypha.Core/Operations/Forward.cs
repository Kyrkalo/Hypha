using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.LinearAlgebra;
using Hypha.Models;

namespace Hypha.Operations;

[Operation("1.0", ExecutionTypes.Forward)]
internal class Forward : IOperation<Model, double[]>
{
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
            output[i] = layer.Neurons[i].Weights.Dot(input) + layer.Neurons[i].Bias;
            var result = layer.Activate(new FunctionParameters() { SingleInput = output[i] });
            output[i] = result.SingleOutput.Value;
        }
        return output;
    }
}
