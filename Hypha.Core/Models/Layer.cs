using Hypha.Interfaces;

namespace Hypha.Models;

internal class Layer : ILayer
{
    private IFunction _function;

    public Neuron[] Neurons { get; set; }

    public FunctionResult Activate(FunctionParameters parameters) => _function?.Activate(parameters);

    public FunctionResult Derivative(FunctionParameters parameters) => _function.Derivative(parameters);

    public void SetFunction(IFunction function) => _function = function;
}
