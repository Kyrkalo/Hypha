namespace Hypha.Core.Tests;

public class HyphaFlowTests
{
    private readonly Hyphaflow hyphaflow;
    public HyphaFlowTests()
    {
        hyphaflow = new Builder().Create()
            .WithActivationFunction(Enums.FunctionTypes.RelU)
            .WithNormalizationFunction()
            .WithLayer(5)
            .WithLayer(5)
            .WithOutputLayer(5)
            .Build();
    }

    [Theory]
    [InlineData(new double[] { 1 ,3 ,2, 3, 7 })]
    public void Forward_Test(double[] input)
    {
        var output = hyphaflow.Forward(input);
        Assert.Equal(5, output.Length);
    }
}
