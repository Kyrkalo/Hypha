using Hypha.Functions;
using Hypha.Models;
using Hypha.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Core.Tests.Operations;

public class HiddenLayerOperationTests
{
    private readonly HiddenLayerOperation hiddenLayerOperation;

    public HiddenLayerOperationTests() => hiddenLayerOperation = new HiddenLayerOperation(new ReLU());

    //[Theory]
    //[InlineData(new double[] { 33, 12, 10, 1, 12, 12, 11, 11 })]
    //[InlineData(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
    //public void Forward_Input_Success(double[] input)
    //{
    //    HiddenLayer layer = new();

    //    var output = hiddenLayerOperation.Forward(layer, input);

    //    Assert.All(output, x => Assert.True(x <= 1));
    //}
}
