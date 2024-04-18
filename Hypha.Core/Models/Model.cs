using Hypha.Interfaces;

namespace Hypha.Models;

public class Model
{
    internal InputLayer InputLayer { get; set; }

    internal List<ILayer> HiddenLayers { get; set; }

    internal OutputLayer OutputLayer { get; set; }
}
