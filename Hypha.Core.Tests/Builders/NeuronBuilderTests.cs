using Hypha.Builders;
using Hypha.Records;

namespace Hypha.Core.Tests.Builders;

public class NeuronBuilderTests
{
    [Fact]
    public void Neuron_Test()
    {
        NeuronBuilder neuronBuilder = new();
        neuronBuilder.Setup(new Setup(0, 10, 10, 0));
        var neuron = neuronBuilder.Build();

        Assert.True(neuron != null);
        Assert.Equal(10, neuron.Weights.Length);
        Assert.Equal(0.05, neuron.Bias);
    }
}
