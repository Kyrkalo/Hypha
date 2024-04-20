using Hypha.Records;

namespace Hypha.Core.Tests.Builders;

public class HiddenLayerBuilderTests
{
    [Theory]
    [InlineData(10, 11)]
    [InlineData(7, 1)]
    [InlineData(6, 5)]
    [InlineData(1, 5)]
    public void Build_Test(int height, int connections)
    {
        Hypha.Builders.Hidden.Builder layerBuilder = new();
        var inputLayer = layerBuilder.Build(new Setup(height, connections));

        Assert.NotNull(inputLayer);
        Assert.True(inputLayer.Neurons.Length == height);
    }
}
