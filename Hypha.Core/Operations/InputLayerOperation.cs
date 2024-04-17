using Hypha.Interfaces;

namespace Hypha.Operations;

internal class InputLayerOperation
{
    private readonly IFunction function;

    public InputLayerOperation(IFunction function) => this.function = function;

    public double[] Forward(double[] input) => input.Select(e => function.Output(e)).ToArray();
}
