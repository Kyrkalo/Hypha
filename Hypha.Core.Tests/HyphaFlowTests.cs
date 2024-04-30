namespace Hypha.Core.Tests;

public class HyphaFlowTests
{
    private readonly Hyphaflow hyphaflow;
    public HyphaFlowTests()
    {
        hyphaflow = new Builder().Create()
            .WithActivationFunction(Enums.FunctionTypes.RelU)
            .WithNormalizationFunction()
            .WithLayer(10)
            .WithLayer(20)
            .WithLayer(20)
            .WithOutputLayer(5)
            .Build();
    }

    [Theory]
    [InlineData(new double[] { 1 ,2 ,4, 3, 3, 4, 12, 3, 1, 12 })]
    public void Forward_Test(double[] input)
    {
        var output = hyphaflow.Forward(input);
        Assert.Equal(5, output.Length);
    }
}
