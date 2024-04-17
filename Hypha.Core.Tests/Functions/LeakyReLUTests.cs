using Hypha.Functions;

namespace Hypha.Core.Tests.Functions;

public class LeakyReLUTests
{
    private readonly LeakyReLU leakReLU = new();

    [Theory]
    [InlineData(0.3)]
    [InlineData(0.01 )]
    [InlineData(0)]
    public void Output_Input_Success(double input)
    {
        var r = leakReLU.Output(input);
        Assert.True(r == input);
    }

    [Theory]
    [InlineData(-0.3)]
    [InlineData(-0.01)]
    public void Output_InputNegative_Success(double input)
    {
        var r = leakReLU.Output(input);
        Assert.True(r == input * 0.01);
    }
}
