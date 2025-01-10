using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders.Hidden;

[Builder("1.0", OperationTypes.Hidden)]
internal class Builder : IBuilder<Layer>
{
    private readonly Neurons.Builder neuronBuilder;

    public Builder() => neuronBuilder = new Neurons.Builder();

    public Layer Build(Setup setup)
    {
        Layer hidden = new();
        hidden.Neurons = Enumerable.Range(0, setup.Neurons).Select(_ => neuronBuilder.Build(setup)).ToArray();
        return hidden;
    }
}
