using Hypha.Builders;
using Hypha.Extensions;
using Hypha.Functions;
using Hypha.Interfaces;
using Hypha.Enums;
using Hypha.Models;

namespace Hypha;

internal class Builder
{
    private Hyphaflow Hyphaflow;
    private readonly IBuilder<HiddenLayer> hiddenLayerBuilder;
    private readonly IBuilder<OutputLayer> outputLayerBuilder;
    private readonly IBuilder<InputLayer> inputLayerBuilder;

    public Builder()
    {
        hiddenLayerBuilder = new Builders.Hidden.Builder();
        outputLayerBuilder = new Builders.Output.Builder();
        inputLayerBuilder = new Builders.Input.Builder();
    }

    public Hyphaflow Build() => Hyphaflow;

    public Builder WithActivationFunction(IFunction function)
    {
        Hyphaflow.ActivationFunction = function;
        return this;
    }

    public Builder WithActivationFunction(FunctionTypes function)
    {
        Hyphaflow.ActivationFunction = function switch
        {
            FunctionTypes.Tanh => new Tanh(),
            FunctionTypes.Sigmoid => new Sigmoid(),
            FunctionTypes.LeakyReLU => new LeakyReLU(),
            FunctionTypes.RelU => new ReLU(),
            _ => throw new ArgumentException("Invalid activation function type")
        };

        return this;
    }

    public Builder WithNormalizationFunction(IFunction function)
    {
        Hyphaflow.NormalizationFunction = function;
        return this;
    }

    public Builder WithNormalizationFunction()
    {
        Hyphaflow.NormalizationFunction = new Normalization();
        return this;
    }

    public Builder Create()
    {
        Hyphaflow = new Hyphaflow() { Hypha = new Models.Model() };
        return this;
    }

    public Builder WithLayer(int height)
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

    public Builder WithOutputLayer(int height)
    {
        Hyphaflow.Hypha.AppendOutputLayer(outputLayerBuilder, new Records.Setup(height, 0));
        return this;
    }
}
