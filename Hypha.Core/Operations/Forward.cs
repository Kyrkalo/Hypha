using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations;

[Operation("1.0", ExecutionTypes.Forward)]
internal class Forward : IOperation<Model, double[]>
{
    public string Name => throw new NotImplementedException();

    public double[] Execute(IFunction normalization, IFunction function, Model t, double[] input)
    {
        normalization.Setup(input);
        var normalized = input.Select(e => normalization.Activate(e)).ToArray();
        
        foreach (var item in t.HiddenLayers)
        {
            normalized = Output(function, item, input);
        }

        return normalized;
    }

    private double[] Output(IFunction function, HiddenLayer layer, double[] input)
    {
        var output = new double[input.Length];
        for(int i = 0; i < layer.Neurons.Length; ++i)
        {
            output[i] = Output(function, layer.Neurons[i], input);
        }
        return output;
    }

    private double Output(IFunction function, Models.Neuron neuron, double[] input)
    {
        double result = input.Zip(neuron.Weights, (x, w) => x * w).Sum() + neuron.Bias;
        return function.Activate(result);
    }
}
