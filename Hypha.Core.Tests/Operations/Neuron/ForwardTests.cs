using Hypha.Interfaces;
using Hypha.Operations.Neuron;
using Hypha.Functions;

namespace Hypha.Core.Tests.Operations.Neuron;

public class ForwardTests
{
    [Theory]
    [InlineData(new double[] { 0.1, 0.1, 0.1, 0.1, 0.1})]
    [InlineData(new double[] { 0.1, 0.01, 0.001, 0.2, 0.2 })]
    [InlineData(new double[] { 0.01, 0.1, 0.01, 0.1, 0.01 })]
    [InlineData(new double[] { 0.2, 0.233, 0.23, 0.23, 0.3 })]
    [InlineData(new double[] { 0.1, 0.091, 0.0001, 0.1, 0.1 })]
    [InlineData(new double[] { 0, 0, 0, 0, 0 })]
    public void Forward_Test(double[] input)
    {
        IFunction function = new ReLU();
        IOperation<Models.Neuron, double> operation = new Forward();
        IBuilder<Models.Neuron> builder = new Hypha.Builders.Neurons.Builder();

        var neuron = builder.Build(new Records.Setup(0, 5));
        var output = operation.Execute(function, neuron, input);
        var expected = input.Select(e => e * 0.005).Sum() + 0.05;

        Assert.NotNull(neuron);
        Assert.True(output == expected);
    }
}
