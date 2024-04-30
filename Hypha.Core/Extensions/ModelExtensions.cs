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
            model.HiddenLayers = new List<HiddenLayer>();

        var lastHiddenLayer = model.HiddenLayers.LastOrDefault() as HiddenLayer;

        if (lastHiddenLayer != null)
        {
            setup = new Setup(setup.Height, lastHiddenLayer.Neurons.Length);
        } 
        else
        {
            setup = new Setup(setup.Height, setup.Height);
        }

        var hiddenLayer = builder.Build(setup);
        model.HiddenLayers.Add(hiddenLayer);
    }

    public static void AppendOutputLayer(this Model model, IBuilder<OutputLayer> builder, Setup setup)
    {
        if (model == null)
            return;

        if (model.HiddenLayers is null || model.HiddenLayers.Count == 0)
            throw new ArgumentException("Initialization error, hidden layers are not initialized");

        var lastHiddenLayer = model.HiddenLayers.LastOrDefault() as HiddenLayer;
        setup = new Setup(setup.Height, lastHiddenLayer.Neurons.Length);
        var outputLayer = builder.Build(setup);
        model.OutputLayer = outputLayer;
    }
}
