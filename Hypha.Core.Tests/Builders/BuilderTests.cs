namespace Hypha.Core.Tests.Builders;

public class BuilderTests
{
    [Fact]
    public void Build_Model_Test()
    {
        var builder = new Builder();
        var hypha = builder.Create()
            .WithLayer(10, Enums.FunctionTypes.RelU)
            .WithLayer(20, Enums.FunctionTypes.RelU)
            .WithLayer(20, Enums.FunctionTypes.RelU)
            .Build();
        Assert.NotNull(hypha);
    }
}
