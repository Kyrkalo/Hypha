using Hypha.Interfaces;

namespace Hypha.Models;

internal class Input : IInput<Model>
{
    public Model Model { get; set; }
    public double[] In { get; set; }
    public double[] Out { get; set; }
    public double[] Target { get; set; }
}
