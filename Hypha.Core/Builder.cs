using Hypha.Builders;
using Hypha.Extensions;

namespace Hypha;

internal class Builder
{
    private Hyphaflow Hyphaflow;
    private readonly HiddenLayerBuilder hiddenLayerBuilder;
    private readonly OutputLayerBuilder outputLayerBuilder;
    private readonly InputLayerBuilder inputLayerBuilder;

    public Builder()
    {
        hiddenLayerBuilder = new HiddenLayerBuilder();
        outputLayerBuilder = new OutputLayerBuilder();
        inputLayerBuilder = new InputLayerBuilder();
    }

    public Hyphaflow Build() => Hyphaflow;

    public Builder Create()
    {
        Hyphaflow = new Hyphaflow() { Hypha = new Models.Model() };
        return this;
    }

    public Builder AppendLayer(int height)
    {
        Append(height, height);
        return this;
    }

    private Builder Append(int height, int connections)
    {
        if (Hyphaflow.Hypha.InputLayer is null || Hyphaflow.Hypha.InputLayer.Inputs.Length == 0)
        {
            Hyphaflow.Hypha.CreateInputLayer(inputLayerBuilder, new Records.Setup(height, connections));
        }
        else
        {
            Hyphaflow.Hypha.AppendHiddenLayer(hiddenLayerBuilder, new Records.Setup(height, connections));
        }
        return this;
    }

    public Builder AppendOutputLayer(int height)
    {
        Hyphaflow.Hypha.AppendOutputLayer(outputLayerBuilder, new Records.Setup(height, 0));
        return this;
    }
}
