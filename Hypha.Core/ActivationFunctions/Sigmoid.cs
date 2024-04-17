using Hypha.Interfaces;

namespace Hypha.ActivationFunctions;

internal class Sigmoid : IFunction
{
    public double Output(double value) => 1 / (1 + Math.Exp(-value));

    public void Setup(double[] inputs) { }
}
