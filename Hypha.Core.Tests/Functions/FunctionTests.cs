using Hypha.Functions;

namespace Hypha.Core.Tests.Functions;

public class FunctionTests
{
    private readonly Normalization normalization = new();
    private readonly Softmax softmax = new();
    private readonly LeakyReLU leakReLU = new();
    private readonly ReLU ReLU = new();

    [Theory]
    [InlineData(new double[] { 33, 12, 10, 1, 12, 12, 11, 11 })]
    [InlineData(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
    public void Output_Input_Normalization_Success(double[] input)
    {
        var r = input.Select(item => normalization.Activate(new Interfaces.FunctionParameters { ArrayInput = input, SingleInput = item}))
            .Select(e => e.SingleOutput);
        Assert.All(r, x => Assert.True(x <= 1));
    }

    [Theory]
    [InlineData(new double[] { 4.8, 1.21,2.385 })]
    public void Check_Softmax_Values_Success(double[] input)
    {
        var result = softmax.Activate(new Interfaces.FunctionParameters { ArrayInput = input }).ArrayOutput;
        Assert.All(result, x => Assert.True(x <= 1));
    }

    [Theory]
    [InlineData(0.3)]
    [InlineData(0.01)]
    [InlineData(0)]
    public void Output_Input_LeakyRelu_Success(double input)
    {
        var r = leakReLU.Activate(new Interfaces.FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == input);
    }

    [Theory]
    [InlineData(-0.3)]
    [InlineData(-0.01)]
    public void Output_InputNegative_LeakyRelu_Success(double input)
    {
        var r = leakReLU.Activate(new Interfaces.FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == input * 0.01);
    }


    [Theory]
    [InlineData(0.3)]
    [InlineData(0.01)]
    [InlineData(0)]
    public void Output_Input_ReLU_Success(double input)
    {
        var r = ReLU.Activate(new Interfaces.FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == input);
    }

    [Theory]
    [InlineData(-0.3)]
    [InlineData(-0.01)]
    public void Output_Input_ReLU_Zero(double input)
    {
        var r = ReLU.Activate(new Interfaces.FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == 0);
    }
}
