using Hypha.Interfaces;

namespace Hypha.Functions;

internal class Tanh : IFunction
{
    public double Output(double value) => Math.Tanh(value);

    public void Setup(double[] inputs) { }
}
