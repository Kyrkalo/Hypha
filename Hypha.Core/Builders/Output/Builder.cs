using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders.Output;

internal class Builder : IBuilder<OutputLayer>
{
    private readonly Neurons.Builder neuronBuilder;

    public Builder() => neuronBuilder = new Neurons.Builder();

    public OutputLayer Build(Setup setup)
    {
        OutputLayer outputLayer = new() { Outputs = new Neuron[setup.Height] };
        for (int i = 0; i < setup.Height; i++)
        {
            outputLayer.Outputs[i] = neuronBuilder.Build(setup);
        }
        return outputLayer;
    }
}
