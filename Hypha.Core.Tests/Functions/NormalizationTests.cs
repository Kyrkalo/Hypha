using Hypha.ActivationFunctions;

namespace Hypha.Core.Tests.Functions;

public class NormalizationTests
{
    private readonly Normalization normalization = new();

    [Theory]
    [InlineData(new double[] { 33, 12, 10, 1, 12, 12, 11, 11 })]
    [InlineData(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
    public void Output_Input_Success(double[] input)
    {
        normalization.Setup(input);

        var r = input.Select(item => normalization.Output(item));
        Assert.All(r, x => Assert.True(x <= 1));
    }
}
