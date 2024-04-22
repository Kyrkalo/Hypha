using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Input;

[Operation("1.0", OperationTypes.Input, ExecutionTypes.Forward)]
internal class Forward : IOperation<InputLayer, double[]>
{
    public string Name => nameof(InputLayer);

    public double[] Execute(IFunction function, InputLayer t, double[] input)
    {
        function.Setup(input);
        return input.Select(e => function.Output(e)).ToArray();
    }
}
