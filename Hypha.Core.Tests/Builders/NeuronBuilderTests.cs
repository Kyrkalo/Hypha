using Hypha.Records;

namespace Hypha.Core.Tests.Builders;

public class NeuronBuilderTests
{
    [Fact]
    public void Neuron_Test()
    {
        Hypha.Builders.Neurons.Builder neuronBuilder = new();
        var neuron = neuronBuilder.Build(new Setup(10, 15));

        Assert.True(neuron != null);
        Assert.Equal(15, neuron.Weights.Length);
        Assert.Equal(0.05, neuron.Bias);
    }
}
