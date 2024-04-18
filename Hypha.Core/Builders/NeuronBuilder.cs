using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class NeuronBuilder : IBuilder<Neuron>
{
    private Setup setup;

    public IBuilder<Neuron> Setup(Setup setup)
    {
        this.setup = setup;
        return this;
    }

    public Neuron Build() => new()
    {
        Bias = 0.05,
        Weights = Enumerable.Range(0, setup.Connections).Select(i => 0.005).ToArray()
    };
}
