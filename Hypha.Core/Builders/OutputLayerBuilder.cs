using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders;

internal class OutputLayerBuilder : IBuilder<OutputLayer>, IDisposable
{
    private Setup setup;

    public void Setup(Setup setup) => this.setup = setup;

    public OutputLayer Build() => new() { Outputs = new decimal[setup.Outputs] };

    public void Dispose() { }
}
