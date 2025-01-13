using Hypha.Models;

namespace Hypha.Interfaces;

internal interface ILayer
{
    Neuron[] Neurons { get; set; }

    void SetFunction(IFunction function);

    FunctionResult Activate(FunctionParameters parameters);

    FunctionResult Derivative(FunctionParameters parameters);
}
