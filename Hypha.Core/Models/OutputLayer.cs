using Hypha.Interfaces;

namespace Hypha.Models;

internal class OutputLayer : ILayer
{
    public decimal[] Neurons { get; internal set; }

    public int Length => throw new NotImplementedException();
}
