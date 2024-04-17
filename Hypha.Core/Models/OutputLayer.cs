using Hypha.Interfaces;

namespace Hypha.Models;

internal class OutputLayer : ILayer
{
    public decimal[] Outputs { get; internal set; }
}
