using Hypha.Functions.Interfaces;
using Hypha.Interfaces;

namespace Hypha.Models;

internal class Layer : ILayer
{
    private IActivationFunction activationFunction;

    private IDerivativeFunction derivativeFunction;

    public Neuron[] Neurons { get; set; }

    public FunctionResult Activate(FunctionParameters parameters) => activationFunction.Execute(parameters);

    public FunctionResult Derivative(FunctionParameters parameters) => derivativeFunction.Execute(parameters);

    public void SetFunction(IFunction function)
    {
        if (function is IActivationFunction)
            activationFunction = function as IActivationFunction;

        if (function is IDerivativeFunction)
            derivativeFunction = function as IDerivativeFunction;
    }
}
