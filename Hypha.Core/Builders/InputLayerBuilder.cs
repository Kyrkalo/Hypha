using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class InputLayerBuilder : IBuilder<InputLayer>, IDisposable
{
    private Setup setup;

    public IBuilder<InputLayer> Setup(Setup setup)
    {
        this.setup = setup;
        return this;
    }

    public InputLayer Build() => new() { Inputs = new double[setup.Height] };

    public void Dispose()
    {
    }

}
