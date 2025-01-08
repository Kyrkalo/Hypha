using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Extensions;

internal static class ModelExtensions
{
    public static void AppendHiddenLayer(this Model model, IBuilder<HiddenLayer> builder, Setup setup)
    {
        if (model == null)
            return;

        if (model.HiddenLayers == null)
            model.HiddenLayers = new List<ILayer>();

        var lastHiddenLayer = model.HiddenLayers.LastOrDefault() as HiddenLayer;

        if (lastHiddenLayer != null)
        {
            setup = new Setup(setup.Neurons, lastHiddenLayer.Neurons.Length);
        } 
        else
        {
            setup = new Setup(setup.Neurons, setup.Connections);
        }

        var hiddenLayer = builder.Build(setup);
        model.HiddenLayers.Add(hiddenLayer);
    }

    public static void AppendOutputLayer(this Model model, IBuilder<OutputLayer> builder, Setup setup)
    {
        if (model == null)
            return;

        var lastHiddenLayer = model.HiddenLayers.LastOrDefault() as HiddenLayer;
        if (lastHiddenLayer == null)
            throw new NullReferenceException("Hidden layers are not initialized.");

        setup = new Setup(setup.Neurons, lastHiddenLayer.Neurons.Length);
        var outputLayer = builder.Build(setup);
        model.OutputLayer = outputLayer;
    }
}
