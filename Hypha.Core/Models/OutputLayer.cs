using Hypha.Interfaces;

namespace Hypha.Models;

internal class OutputLayer : ILayer
{
    public Neuron[] Neurons { get; set; }
}
