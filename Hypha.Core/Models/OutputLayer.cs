using Hypha.Interfaces;

namespace Hypha.Models;

internal class OutputLayer : ILayer
{
    public Neuron[] Outputs { get; internal set; }
}
