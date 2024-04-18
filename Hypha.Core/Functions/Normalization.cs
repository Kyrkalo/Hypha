using Hypha.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Normalization function for input values.
/// X = (X - Xmin) / (Xmax = Xmin)
/// </summary>
internal class Normalization : IFunction
{
    private double min;

    private double max;

    public double Output(double value) => max == 0 || min == 0 ? 0 : (value - min) / (max - min);

    public void Setup(double[] inputs) => (min, max) = (inputs.Min(), inputs.Max());
}
