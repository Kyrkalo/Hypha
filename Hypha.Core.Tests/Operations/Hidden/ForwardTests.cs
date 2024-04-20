using Hypha.Functions;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Core.Tests.Operations.Hidden;

public class ForwardTests
{
    [Theory]
    [InlineData(new double[] { 0.1, 0.1, 0.1, 0.1, 0.1 })]
    [InlineData(new double[] { 0.1, 0.01, 0.001, 0.2, 0.2 })]
    [InlineData(new double[] { 0.01, 0.1, 0.01, 0.1, 0.01 })]
    [InlineData(new double[] { 0.2, 0.233, 0.23, 0.23, 0.3 })]
    [InlineData(new double[] { 0.1, 0.091, 0.0001, 0.1, 0.1 })]
    [InlineData(new double[] { 0, 0, 0, 0, 0 })]
    public void Forward_Test(double[] input)
    {
        IFunction function = new ReLU();
        IBuilder<HiddenLayer> builder = new Hypha.Builders.Hidden.Builder();
        IOperation<Models.Neuron, double> nOperation = new Hypha.Operations.Neuron.Forward();
        IOperation<HiddenLayer, double[]> lOperation = new Hypha.Operations.Hidden.Forward(nOperation);

        var layer = builder.Build(new Records.Setup(5, 5));
        var output = lOperation.Execute(function, layer, input);

        double[] expected = new double[input.Length];
        for(int i = 0; i < input.Length; i++)
        {
            expected[i] = input.Select(e => e * 0.005).Sum() + 0.05;
        }

        Assert.NotNull(layer);
        Assert.Equal(expected, output);
    }
}
