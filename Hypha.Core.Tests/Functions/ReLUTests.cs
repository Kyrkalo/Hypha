using Hypha.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Core.Tests.Functions;

public class ReLUTests
{
    private readonly ReLU ReLU = new();

    [Theory]
    [InlineData(0.3)]
    [InlineData(0.01)]
    [InlineData(0)]
    public void Output_Input_Success(double input)
    {
        var r = ReLU.Activate(input);
        Assert.True(r == input);
    }

    [Theory]
    [InlineData(-0.3)]
    [InlineData(-0.01)]
    public void Output_Input_Zero(double input)
    {
        var r = ReLU.Activate(input);
        Assert.True(r == 0);
    }
}
