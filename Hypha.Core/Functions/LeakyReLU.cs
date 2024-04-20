using Hypha.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Leaky ReLU (Rectified Linear Unit) is an activation function used in neural networks.
/// It is similar to the ReLU function but allows a small, non-zero gradient when the input is negative.
/// This helps prevent the "dying ReLU" problem where neurons can become inactive during training.
/// The function returns x if x is positive and a small fraction (usually a constant like 0.01) of x if x is negative.
/// Leaky ReLU(x) = x if x >= 0, else alpha * x where alpha is a small positive constant. 
/// </summary>
internal class LeakyReLU : IFunction
{
    public double Output(double value) => value < 0 ? 0.01 * value : value;

    public void Setup(double[] inputs) { }
}
