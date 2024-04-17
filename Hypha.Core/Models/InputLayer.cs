using Hypha.Interfaces;

namespace Hypha.Models;

internal class InputLayer : ILayer
{
    public double[] Inputs { get; internal set; }

    public int Length => Inputs.Length;
}
