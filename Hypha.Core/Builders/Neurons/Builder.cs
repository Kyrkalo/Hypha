﻿using Hypha.Attributes;
using Hypha.Enums;
using Hypha.Interfaces;
using Hypha.Models;
using Hypha.Records;

namespace Hypha.Builders.Neurons;

[Builder("1.0", OperationTypes.Neuron)]
internal class Builder : IBuilder<Neuron>
{
    public Neuron Build(Setup setup) => new ()
    {
        Bias = 0.05,
        Weights = Enumerable.Range(0, setup.Connections).Select(i => 0.005).ToArray()
    };
}
