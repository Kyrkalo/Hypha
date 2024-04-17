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
    [InlineData(10, 11, 12, 13)]
    [InlineData(10, 5, 12, 1)]
    [InlineData(10, 5, 3, 4)]
    [InlineData(10, 5, 3, 5)]
    public void Test(int i, int w, int s, int t)
    {
        OutputLayerBuilder outputLayerBuilder = new();
        outputLayerBuilder.Setup(new Setup(i, w, s, t));
        var outputLayer = outputLayerBuilder.Build();

        Assert.NotNull(outputLayer);
        Assert.True(outputLayer.Outputs.Length == t);
    }
}
