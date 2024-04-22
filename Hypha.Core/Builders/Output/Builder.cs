using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders.Output;

[Builder("1.0", OperationTypes.Output)]
internal class Builder : IBuilder<OutputLayer>
{
    private readonly Neurons.Builder neuronBuilder;

    public Builder() => neuronBuilder = new Neurons.Builder();

    public OutputLayer Build(Setup setup)
    {
        OutputLayer output = new();
        output.Outputs = Enumerable.Range(0, setup.Height).Select(_ => neuronBuilder.Build(setup)).ToArray();
        return output;
    }
}
