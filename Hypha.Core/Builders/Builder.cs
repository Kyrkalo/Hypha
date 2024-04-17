using Hypha.Interfaces;
using Hypha.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Builders;

internal class Builder : IBuilder<Hypha.Models.Hypha>, IDisposable
{
    private readonly HiddenLayerBuilder[] hiddenLayerBuilder;
    private readonly OutputLayerBuilder outputLayerBuilder;
    private readonly InputLayerBuilder inputLayerBuilder;
    private Setup setup;

    public void Setup(Setup setup) => this.setup = setup;

    public Models.Hypha Build()
    {
        return null;
    }

    private void Setup()
    {
    }

    public void Dispose()
    {
    }
}
