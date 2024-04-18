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

    public void Create() => Hyphaflow = new Hyphaflow();

    public Hyphaflow Append(int height)
    {
        Append(height, height);
        return Hyphaflow;
    }

    private Hyphaflow Append(int height, int connections)
    {
        if (Hyphaflow.Hypha.InputLayer is null || Hyphaflow.Hypha.InputLayer.Inputs.Length == 0)
        {
            Hyphaflow.Hypha.CreateInputLayer(inputLayerBuilder, new Records.Setup(height, connections));
        }
        else
        {
            Hyphaflow.Hypha.AppendHiddenLayer(hiddenLayerBuilder, new Records.Setup(height, connections));
        }
        return Hyphaflow;
    }

    public Hyphaflow AppendOutPutLayer(int height)
    {
        Hyphaflow.Hypha.AppendOutputLayer(outputLayerBuilder, new Records.Setup(height, 0));
        return Hyphaflow;
    }
}
