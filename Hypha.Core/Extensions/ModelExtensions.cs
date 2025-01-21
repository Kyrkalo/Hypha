using Hypha.Functions.Interfaces;
using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Extensions;

internal static class ModelExtensions
{
    public static void Layer(this Model model, IBuilder<Layer> builder, IFunction function, Setup setup)
    {
        if (model == null)
            return;

        if (model.Layers == null)
            model.Layers = new List<ILayer>();

        var lastHiddenLayer = model.Layers.LastOrDefault() as Layer;

        if (lastHiddenLayer != null)
        {
            setup = new Setup(setup.Neurons, lastHiddenLayer.Neurons.Length);
        } 
        else
        {
            setup = new Setup(setup.Neurons, setup.Connections);
        }

        var hiddenLayer = builder.Build(setup);
        hiddenLayer.ActivationFunctionName = function.GetType().Name;
        model.Layers.Add(hiddenLayer);
    }
}
