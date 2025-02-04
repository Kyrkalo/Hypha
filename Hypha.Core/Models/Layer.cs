using Hypha.Interfaces;

namespace Hypha.Models;

internal class Layer : ILayer
{
    public Neuron[] Neurons { get; set; }

    public string FunctionName { get; set; }
}
