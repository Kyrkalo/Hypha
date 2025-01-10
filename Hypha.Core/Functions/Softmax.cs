using Hypha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypha.Functions;

/// <summary>
/// The Softmax function is typically used in the output layer of a 
/// neural network for classification tasks. It converts raw scores (logits) 
/// into probabilities, ensuring the sum of probabilities equals 1.
/// </summary>
internal class Softmax : IFunction
{
    public double Activate(double input)
    {
        throw new NotImplementedException();
    }

    public double Backward(double input)
    {
        throw new NotImplementedException();
    }

    public void Setup(double[] inputs)
    {
        throw new NotImplementedException();
    }
}
