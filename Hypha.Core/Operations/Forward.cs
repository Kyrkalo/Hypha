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

    public double[] Execute(IFunction normalization, IFunction function, Model t, double[] input)
    {
        normalization.Setup(input);
        var values = input.Select(e => normalization.Activate(e)).ToArray();
        
        foreach (var item in t.HiddenLayers)
        {
            values = Output(function, item, values);
        }

        return values;
    }

    private double[] Output(IFunction function, ILayer layer, double[] input)
    {
        var output = new double[layer.Neurons.Length];
        for(int i = 0; i < layer.Neurons.Length; ++i)
        {
            output[i] = MatrixUtils.Dot(layer.Neurons[i].Weights, input) + layer.Neurons[i].Bias;
            output[i] = function.Activate(output[i]);
        }
        return output;
    }
}
