using Hypha.Builders;
using Hypha.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Core.Tests.Builders;

public class InputLayerBuilderTests
{
    [Theory]
    [InlineData(10, 11)]
    [InlineData(7, 5)]
    [InlineData(6, 5)]
    [InlineData(1, 5)]
    public void Build_Test(int height, int connections)
    {
        Hypha.Builders.Input.Builder inputLayerBuilder = new();
        var inputLayer = inputLayerBuilder.Build(new Setup(height, connections));

        Assert.NotNull(inputLayer);
        Assert.True(inputLayer.Inputs.Length == height);
    }
}
