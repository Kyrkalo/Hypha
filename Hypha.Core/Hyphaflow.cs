using Hypha.Interfaces;
using Hypha.Models;

namespace Hypha;

public class Hyphaflow
{
    /// <summary>
    /// Neural network model representing connections between layers and neurons
    /// </summary>
    internal Model Hypha { get; set; }

    /// <summary>
    /// Activation function used to activate the calculated value of a neuron
    /// </summary>
    internal IFunction ActivationFunction { get; set; }

    /// <summary>
    /// Normalization function applied to the input data or intermediate layers of the model
    /// </summary>
    internal IFunction NormalizationFunction { get; set; }
}
