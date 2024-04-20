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
        HiddenLayer hidden = new();
        hidden.Neurons = Enumerable.Range(0, setup.Height).Select(_ => neuronBuilder.Build(setup)).ToArray();
        return hidden;
    }
}
