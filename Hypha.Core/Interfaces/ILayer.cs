using Hypha.Models;

namespace Hypha.Interfaces;

internal interface ILayer
{
    Neuron[] Neurons { get; set; }
}
