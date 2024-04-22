﻿using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha.Operations.Output;

[Operation("1.0", OperationTypes.Output, ExecutionTypes.Forward)]
internal class Forward : IOperation<OutputLayer, double[]>
{
    private readonly IOperation<Models.Neuron, double> neuronOperation;

    public Forward(IOperation<Models.Neuron, double> neuronOperation) => this.neuronOperation = neuronOperation;

    public string Name => nameof(OutputLayer);

    public double[] Execute(IFunction function, OutputLayer layer, double[] input)
    {
        if (layer == null)
            return null;

        return layer.Outputs.Select(e => neuronOperation.Execute(function, e, input)).ToArray();
    }
}
