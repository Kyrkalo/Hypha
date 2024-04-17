using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations;

internal class HiddenLayerOperation : IOperation
{
    private readonly NeuronOperation neuronOperation;

    private readonly IFunction activationFunction;

    public HiddenLayerOperation(IFunction activationFunction)
    {
        this.activationFunction = activationFunction;
        this.neuronOperation = new NeuronOperation();
    }

    public int Length => throw new NotImplementedException();

    public double[] Forward(ILayer layer, double[] input)
    {
        if (layer is null)
            return default;
        
        //var output = new double[layer.Length];

        //for(int i = 0; i < layer.Length; i++)
        //{
        //    //double value = neuronOperation.Forward(layer.GetNeuron<Neuron>(i), input);
        //    //output[i] = activationFunction.Output(value);
        //}

        return default;
    }

    public T GetNeuron<T>(int index)
    {
        throw new NotImplementedException();
    }
}
