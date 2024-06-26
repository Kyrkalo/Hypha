﻿using Hypha.Extensions;
using Hypha.Functions;
using Hypha.Interfaces;
using Hypha.Enums;
using Hypha.Models;

namespace Hypha;

internal class Builder
{
    private readonly string version = "1.0";

    private Hyphaflow Hyphaflow;
    private readonly IBuilder<HiddenLayer> hiddenLayerBuilder;
    private readonly IBuilder<OutputLayer> outputLayerBuilder;

    public Builder()
    {
        hiddenLayerBuilder = this.CreateBuilder<IBuilder<HiddenLayer>>(version, OperationTypes.Hidden);
        outputLayerBuilder = this.CreateBuilder<IBuilder<OutputLayer>>(version, OperationTypes.Output);
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
        Hyphaflow = new Hyphaflow();
        return this;
    }

    public Builder WithLayer(int height)
    {
        Append(height, height);
        return this;
    }

    private Builder Append(int height, int connections)
    {
        Hyphaflow.Hypha.AppendHiddenLayer(hiddenLayerBuilder, new Records.Setup(height, connections));
        return this;
    }

    public Builder WithOutputLayer(int height)
    {
        Hyphaflow.Hypha.AppendOutputLayer(outputLayerBuilder, new Records.Setup(height, 0));
        return this;
    }
}
