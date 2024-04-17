using Hypha.Interfaces;

namespace Hypha.ActivationFunctions;

internal class ReLU : IFunction
{
    public double Output(double value) => Math.Max(0, value);

    public void Setup(double[] inputs) { }
}
