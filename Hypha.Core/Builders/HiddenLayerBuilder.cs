using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class HiddenLayerBuilder : IBuilder<HiddenLayer>, IDisposable
{
    private Setup setup;

    private readonly NeuronBuilder neuronBuilder;

    public HiddenLayerBuilder() => neuronBuilder = new NeuronBuilder();

    public IBuilder<HiddenLayer> Setup(Setup setup)
    {
        this.setup = setup;
        neuronBuilder.Setup(setup);
        return this;
    }

    public HiddenLayer Build()
    {
        HiddenLayer hiddenLayer = new HiddenLayer() { Neurons = new Neuron[setup.Height] };
        for (int i = 0; i < setup.Height; i++)
        {
            hiddenLayer.Neurons[i] = neuronBuilder.Setup(setup).Build();
        }
        return hiddenLayer;
    }

    public void Dispose()
    {
    }
}
