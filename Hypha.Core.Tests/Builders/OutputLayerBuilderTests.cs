using Hypha.Records;

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
        Hypha.Builders.Output.Builder outputLayerBuilder = new();
        var outputLayer = outputLayerBuilder.Build(new Setup(height, connections));

        Assert.NotNull(outputLayer);
        Assert.True(outputLayer.Outputs.Length == height);
    }
}
