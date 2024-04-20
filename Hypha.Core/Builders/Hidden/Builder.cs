using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders.Hidden;

internal class Builder : IBuilder<HiddenLayer>
{
    private readonly Neurons.Builder neuronBuilder;

    public Builder() => neuronBuilder = new Neurons.Builder();

    public HiddenLayer Build(Setup setup)
    {
        HiddenLayer hiddenLayer = new() { Neurons = new Neuron[setup.Height] };
        for (int i = 0; i < setup.Height; i++)
        {
            hiddenLayer.Neurons[i] = neuronBuilder.Build(setup);
        }
        return hiddenLayer;
    }
}
