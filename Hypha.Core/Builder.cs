using Hypha.Extensions;
using Hypha.Functions;
using Hypha.Interfaces;
using Hypha.Enums;
using Hypha.Models;
using Hypha.Functions.Interfaces;

namespace Hypha;

internal class Builder
{
    private readonly string version = "1.0";

    private Hyphaflow Hyphaflow;

    private readonly IBuilder<Layer> hiddenLayerBuilder;

    public Builder()
    {
        hiddenLayerBuilder = this.CreateBuilder<IBuilder<Layer>>(version, OperationTypes.Hidden);
    }

    public Hyphaflow Build() => Hyphaflow;

    private IFunction WithActivationFunction(FunctionTypes function) => function switch
    {
        FunctionTypes.Tanh => new Tanh(),
        FunctionTypes.Sigmoid => new Sigmoid(),
        FunctionTypes.LeakyReLU => new LeakyReLU(),
        FunctionTypes.RelU => new ReLU(),
        FunctionTypes.Normalization => new Normalization(),
        FunctionTypes.Softmax => new Softmax(),
        _ => throw new ArgumentException("Invalid activation function type")
    };

    public Builder Create()
    {
        Hyphaflow = new Hyphaflow();
        return this;
    }

    public Builder WithLayer(int neurons, IFunction function)
    {
        Append(neurons, neurons, function);
        return this;
    }

    public Builder WithLayer(int neurons, FunctionTypes functionType)
    {
        Append(neurons, neurons, functionType);
        return this;
    }

    public Builder WithLayer(int connections, int neurons, FunctionTypes functionType)
    {
        Append(neurons, connections, functionType);
        return this;
    }

    public Builder WithLayer(int connections, int neurons, IFunction function)
    {
        Append(neurons, connections, function);
        return this;
    }

    private Builder Append(int neurons, int connections, FunctionTypes functionType)
    {
        var function = WithActivationFunction(functionType);
        Hyphaflow.Hypha.Layer(hiddenLayerBuilder, function, new Records.Setup(neurons, connections));
        return this;
    }

    private Builder Append(int neurons, int connections, IFunction function)
    {
        Hyphaflow.Hypha.Layer(hiddenLayerBuilder, function, new Records.Setup(neurons, connections));
        return this;
    }
}
