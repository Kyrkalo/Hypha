using Hypha.Interfaces;

namespace Hypha.Functions;

internal class ReLU : IFunction
{
    public double Output(double value) => Math.Max(0, value);

    public void Setup(double[] inputs) { }
}
