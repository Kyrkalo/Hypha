using Hypha.Interfaces;
using Moq;

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

    [Fact]
    public void Hardcode_Values1_Test()
    {
        Mock<IFunction> mockFunction = new Mock<IFunction>();
        mockFunction.Setup(x => x.Activate(It.IsAny<double>())).Returns((double input) => input);

        Hyphaflow flow = new Builder().Create()
            .WithNormalizationFunction(mockFunction.Object)
            .WithLayer(3, 1)
            .Build();

        flow.ActivationFunction = mockFunction.Object;

        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[0] = 0.2;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[1] = 0.8;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[2] = -0.5;
        flow.Hypha.HiddenLayers[0].Neurons[0].Bias = 2;


        var output = flow.Forward(new double[] { 1, 2, 3 });
        Assert.Equal(2.3, output[0]);
    }

    [Fact]
    public void Hardcode_Values2_Test()
    {
        Mock<IFunction> mockFunction = new Mock<IFunction>();
        mockFunction.Setup(x => x.Activate(It.IsAny<double>())).Returns((double input) => input);

        Hyphaflow flow = new Builder().Create()
            .WithNormalizationFunction(mockFunction.Object)
            .WithLayer(4, 1)
            .Build();

        flow.ActivationFunction = mockFunction.Object;

        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[0] = 0.2;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[1] = 0.8;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[2] = -0.5;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[3] = 1.0;
        flow.Hypha.HiddenLayers[0].Neurons[0].Bias = 2;


        var output = flow.Forward(new double[] { 1, 2, 3, 2.5 });
        Assert.Equal(4.8, output[0]);
    }

    [Fact]
    public void Hardcode_Values3_Test()
    {
        Mock<IFunction> mockFunction = new Mock<IFunction>();
        mockFunction.Setup(x => x.Activate(It.IsAny<double>())).Returns((double input) => input);

        Hyphaflow flow = new Builder().Create()
            .WithNormalizationFunction(mockFunction.Object)
            .WithLayer(4, 3)
            .Build();

        flow.ActivationFunction = mockFunction.Object;

        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[0] = 0.2;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[1] = 0.8;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[2] = -0.5;
        flow.Hypha.HiddenLayers[0].Neurons[0].Weights[3] = 1.0;
        flow.Hypha.HiddenLayers[0].Neurons[0].Bias = 2;

        flow.Hypha.HiddenLayers[0].Neurons[1].Weights[0] = 0.5;
        flow.Hypha.HiddenLayers[0].Neurons[1].Weights[1] = -0.91;
        flow.Hypha.HiddenLayers[0].Neurons[1].Weights[2] = 0.26;
        flow.Hypha.HiddenLayers[0].Neurons[1].Weights[3] = -0.5;
        flow.Hypha.HiddenLayers[0].Neurons[1].Bias = 3;

        flow.Hypha.HiddenLayers[0].Neurons[2].Weights[0] =-0.26;
        flow.Hypha.HiddenLayers[0].Neurons[2].Weights[1] = -0.27;
        flow.Hypha.HiddenLayers[0].Neurons[2].Weights[2] = 0.17;
        flow.Hypha.HiddenLayers[0].Neurons[2].Weights[3] = 0.87;
        flow.Hypha.HiddenLayers[0].Neurons[2].Bias = 0.5;


        var output = flow.Forward(new double[] { 1, 2, 3, 2.5 });
        Assert.Equal(4.8, output[0]);
        Assert.Equal(1.21, output[1]);
        Assert.Equal(2.385, output[2]);
    }

    [Fact]
    public void Check_Data_Structure1_Test()
    {
        Hyphaflow flow = new Builder().Create()
            .WithLayer(3, 1)
            .Build();

        Assert.Single(flow.Hypha.HiddenLayers);
        Assert.Single(flow.Hypha.HiddenLayers[0].Neurons);
        Assert.Equal(3, flow.Hypha.HiddenLayers[0].Neurons[0].Weights.Length);
    }

    [Fact]
    public void Check_Data_Structure2_Test()
    {
        Hyphaflow flow = new Builder().Create()
            .WithLayer(3, 2)
            .WithLayer(4)
            .Build();

        Assert.Equal(2, flow.Hypha.HiddenLayers.Count);
        Assert.Equal(2, flow.Hypha.HiddenLayers[0].Neurons.Length);
        Assert.Equal(3, flow.Hypha.HiddenLayers[0].Neurons[0].Weights.Length);
        Assert.Equal(3, flow.Hypha.HiddenLayers[0].Neurons[1].Weights.Length);

        Assert.Equal(4, flow.Hypha.HiddenLayers[1].Neurons.Length);
        Assert.Equal(2, flow.Hypha.HiddenLayers[1].Neurons[0].Weights.Length);
        Assert.Equal(2, flow.Hypha.HiddenLayers[1].Neurons[1].Weights.Length);
        Assert.Equal(2, flow.Hypha.HiddenLayers[1].Neurons[2].Weights.Length);
        Assert.Equal(2, flow.Hypha.HiddenLayers[1].Neurons[3].Weights.Length);
    }

    [Theory]
    [InlineData(new double[] { 1 ,3 ,2, 3, 7 })]
    public void Forward_Test(double[] input)
    {
        var output = hyphaflow.Forward(input);
        Assert.Equal(5, output.Length);
    }
}
