using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class OutputLayerBuilder : IBuilder<OutputLayer>, IDisposable
{
    private Setup setup;

    private NeuronBuilder neuronBuilder;

    public OutputLayerBuilder() => neuronBuilder = new NeuronBuilder();

    public IBuilder<OutputLayer> Setup(Setup setup)
    {
        this.setup = setup;
        neuronBuilder.Setup(setup);
        return this;
    }

    public OutputLayer Build()
    {
        OutputLayer outputLayer = new() { Outputs = new Neuron[setup.Height] };
        for (int i = 0; i < setup.Height; i++)
        {
            outputLayer.Outputs[i] = neuronBuilder.Setup(setup).Build();
        }
        return outputLayer;
    }

    public void Dispose() { }
}
