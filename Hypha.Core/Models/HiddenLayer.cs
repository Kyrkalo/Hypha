using Hypha.Interfaces;

namespace Hypha.Models;

internal class HiddenLayer : ILayer
{
    public Neuron[] Neurons { get; internal set; }

    public int Length => Neurons?.Length ?? 0;
}
