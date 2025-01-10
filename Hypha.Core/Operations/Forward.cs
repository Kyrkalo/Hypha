using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.LinearAlgebra;
using Hypha.Models;

namespace Hypha.Operations;

[Operation("1.0", ExecutionTypes.Forward)]
internal class Forward : IOperation<Model, double[]>
{
    public string Name => throw new NotImplementedException();

    public double[] Execute(IFunction normalization, Model t, double[] input)
    {        
        foreach (var item in t.Layers)
        {
            input = Calculate(item, input);
        }
        return input;
    }

    private double[] Calculate(ILayer layer, double[] input)
    {
        var output = new double[layer.Neurons.Length];
        for(int i = 0; i < layer.Neurons.Length; ++i)
        {
            output[i] = layer.Neurons[i].Weights.Dot(input) + layer.Neurons[i].Bias;
            output[i] = layer.ActivationFunction.Activate(output[i]);
        }
        return output;
    }
}
