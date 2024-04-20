using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Input;

internal class Forward : IOperation<InputLayer, double[]>
{
    public string Name => nameof(InputLayer);

    public double[] Execute(IFunction function, InputLayer t, double[] input)
    {
        function.Setup(input);
        return input.Select(e => function.Output(e)).ToArray();
    }
}
