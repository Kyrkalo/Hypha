using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class InputLayerBuilder : IBuilder<InputLayer>, IDisposable
{
    private Setup setup;

    public void Setup(Setup setup) => this.setup = setup;

    public InputLayer Build() => new() { Inputs = new double[setup.Inputs] };

    public void Dispose()
    {
    }

}
