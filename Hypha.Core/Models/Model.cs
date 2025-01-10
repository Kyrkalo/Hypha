using Hypha.Interfaces;

namespace Hypha.Models;

public class Model
{
    internal List<ILayer> Layers { get; set; }

    internal ILayer OutputLayer { get; set; }
}
