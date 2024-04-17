using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class HiddenLayerBuilder : IBuilder<HiddenLayer>, IDisposable
{
    private Setup setup;

    public void Setup(Setup setup) => this.setup = setup;

    public HiddenLayer Build()
    {
        var neuronBuilder = new NeuronBuilder();

        neuronBuilder.Setup(setup);

        return new HiddenLayer()
        {
            Neurons = Enumerable.Range(0, setup.Width).Select(i => neuronBuilder.Build()).ToArray()
        };
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
