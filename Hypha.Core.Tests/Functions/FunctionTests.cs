using Hypha.Functions;
using Hypha.Functions.Interfaces;

namespace Hypha.Core.Tests.Functions;

public class FunctionTests
{
    [Theory]
    [InlineData(new double[] { 33, 12, 10, 1, 12, 12, 11, 11 })]
    [InlineData(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
    public void Output_Input_Normalization_Success(double[] input)
    {
        IActivationFunction normalization = new Normalization();
        var r = input.Select(item => normalization.Execute(new FunctionParameters { ArrayInput = input, SingleInput = item }))
            .Select(e => e.SingleOutput);
        Assert.All(r, x => Assert.True(x <= 1));
    }

    [Theory]
    [InlineData(new double[] { 4.8, 1.21, 2.385 })]
    public void Check_Softmax_Values_Success(double[] input)
    {
        IActivationFunction softmax = new Softmax();
        var result = softmax.Execute(new FunctionParameters { ArrayInput = input }).ArrayOutput;
        Assert.All(result, x => Assert.True(x <= 1));
    }

    [Theory]
    [InlineData(0.3)]
    [InlineData(0.01)]
    [InlineData(0)]
    public void Output_Input_LeakyRelu_Success(double input)
    {
        IActivationFunction leakReLU = new LeakyReLU();
        var r = leakReLU.Execute(new FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == input);
    }

    [Theory]
    [InlineData(-0.3)]
    [InlineData(-0.01)]
    public void Output_InputNegative_LeakyRelu_Success(double input)
    {
        IActivationFunction leakReLU = new LeakyReLU();
        var r = leakReLU.Execute(new FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == input * 0.01);
    }


    [Theory]
    [InlineData(0.3)]
    [InlineData(0.01)]
    [InlineData(0)]
    public void Output_Input_ReLU_Success(double input)
    {
        IActivationFunction ReLU = new ReLU();
        var r = ReLU.Execute(new FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == input);
    }

    [Theory]
    [InlineData(-0.3)]
    [InlineData(-0.01)]
    public void Output_Input_ReLU_Zero(double input)
    {
        IActivationFunction ReLU = new ReLU();
        var r = ReLU.Execute(new FunctionParameters() { SingleInput = input }).SingleOutput;
        Assert.True(r == 0);
    }
}
