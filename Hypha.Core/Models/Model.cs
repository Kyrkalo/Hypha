namespace Hypha.Models;

public class Model
{
    internal InputLayer InputLayer { get; set; }

    internal List<HiddenLayer> HiddenLayers { get; set; }

    internal OutputLayer OutputLayer { get; set; }
}
