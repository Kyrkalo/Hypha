using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class NeuronBuilder : IBuilder<Neuron>
{
    private Setup setup;

    public void Setup(Setup setup) => this.setup = setup;

    public Neuron Build() => new()
    {
        Bias = 0.05,
        Weights = Enumerable.Range(0, setup.Height).Select(i => 0.005).ToArray()
    };
}
