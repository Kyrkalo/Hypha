using Hypha.Interfaces;

namespace Hypha.ActivationFunctions;

internal class Tanh : IFunction
{
    public double Output(double value) => Math.Tanh(value);

    public void Setup(double[] inputs) { }
}
