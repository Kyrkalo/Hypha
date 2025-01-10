using Hypha.LinearAlgebra;

namespace Hypha.Core.Tests;

public class MathTests
{
    [Theory]
    [InlineData(new double[] { 0.7, 0.1, 0.2 }, new double[] { 1, 0, 0 }, 0.35667494393873245)]
    public void Forward_Test(double[] output, double[] target, double loss)
    {
        var result = MathUtils.Loss(output, target);
        Assert.Equal(loss, result);
    }
}
