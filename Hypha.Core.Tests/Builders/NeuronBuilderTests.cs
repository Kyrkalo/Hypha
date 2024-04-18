using Hypha.Builders;
using Hypha.Records;

namespace Hypha.Core.Tests.Builders;

public class NeuronBuilderTests
{
    [Fact]
    public void Neuron_Test()
    {
        NeuronBuilder neuronBuilder = new();
        var neuron = neuronBuilder.Setup(new Setup(10, 15)).Build();

        Assert.True(neuron != null);
        Assert.Equal(15, neuron.Weights.Length);
        Assert.Equal(0.05, neuron.Bias);
    }
}
