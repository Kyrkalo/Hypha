using Hypha.Interfaces;

namespace Hypha.Functions;

internal class LeakyReLU : IFunction
{
    public double Output(double value) => value < 0 ? 0.01 * value : value;

    public void Setup(double[] inputs) { }
}
