using Hypha.Builders;
using Hypha.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Core.Tests.Builders;

public class OutputLayerBuilderTests
{
    [Theory]
    [InlineData(10, 11)]
    [InlineData(9, 5)]
    [InlineData(10, 7)]
    [InlineData(10, 5)]
    public void Build_Test(int height, int connections)
    {
        OutputLayerBuilder outputLayerBuilder = new();
        var outputLayer = outputLayerBuilder.Setup(new Setup(height, connections)).Build();

        Assert.NotNull(outputLayer);
        Assert.True(outputLayer.Outputs.Length == height);
    }
}
