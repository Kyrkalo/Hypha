using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations;

[Operation("1.0", ExecutionTypes.Backward)]
internal class Backward : IOperation<Model, double[]>
{
    public string Name => throw new NotImplementedException();

    public double[] Execute(IFunction normalization, Model t, double[] input)
    {
        throw new NotImplementedException();
    }
}
