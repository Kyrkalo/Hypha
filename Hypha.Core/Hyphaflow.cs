using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha;

public class Hyphaflow
{
    private readonly IOperation<InputLayer, double[]> InputLayer;
    private readonly IOperation<OutputLayer, double[]> OutputLayer;
    private readonly IOperation<HiddenLayer, double[]> HiddenLayer;
    private readonly IOperation<Models.Neuron, double> NeuronOperation;

    internal Hyphaflow()
    {
        Hypha = new Model();
        NeuronOperation = new Operations.Neuron.Forward();
        InputLayer = new Operations.Input.Forward();
        HiddenLayer = new Operations.Hidden.Forward(NeuronOperation);
        OutputLayer = new Operations.Output.Forward(NeuronOperation);
    }

    /// <summary>
    /// Neural network model representing connections between layers and neurons
    /// </summary>
    internal Model Hypha { get; set; }

    /// <summary>
    /// Activation function used to activate the calculated value of a neuron
    /// </summary>
    internal IFunction ActivationFunction { get; set; }

    /// <summary>
    /// Normalization function applied to the input data or intermediate layers of the model
    /// </summary>
    internal IFunction NormalizationFunction { get; set; }

    public double[] Forward(double[] input)
    {
        var output = InputLayer.Execute(NormalizationFunction, Hypha.InputLayer, input);
        foreach(var item in Hypha.HiddenLayers)
        {
            output = HiddenLayer.Execute(ActivationFunction, item as HiddenLayer, output);
        }
        return OutputLayer.Execute(ActivationFunction, Hypha.OutputLayer, output);
    }
}
