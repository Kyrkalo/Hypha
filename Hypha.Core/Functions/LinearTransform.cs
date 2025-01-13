﻿using Hypha.Interfaces;
using Hypha.LinearAlgebra;

namespace Hypha.Functions;

/// <summary>
/// LinearTransform used in forward propagation before applying the activation function.
/// </summary>
internal class LinearTransform : IFunction
{
    public FunctionResult Activate(FunctionParameters parameters)
    {
        if (parameters.SingleInput != null && parameters.ArrayInput != null && parameters.ArrayWeight != null)
        {
            var output = parameters.ArrayWeight.Dot(parameters.ArrayInput) + parameters.SingleInput;
            return new FunctionResult(SingleOutput: output.Value);
        }
        throw new ArgumentException("Missing bias, weights and inputs values.");
    }

    public FunctionResult Derivative(FunctionParameters parameters)
    {
        throw new NotImplementedException();
    }
}
