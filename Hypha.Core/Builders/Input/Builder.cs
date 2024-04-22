using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders.Input;

[Builder("1.0", OperationTypes.Input)]
internal class Builder : IBuilder<InputLayer>
{
    public InputLayer Build(Setup setup) => new() { Inputs = new double[setup.Height] };
}
