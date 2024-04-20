using Hypha.Interfaces;

namespace Hypha.Functions;

/// <summary>
/// Normalization is a process of scaling data to a common range or distribution.
/// This normalization function scales input values to a range between 0 and 1.
/// It subtracts the minimum value from each input value and then divides by the range (max - min).
/// This ensures that all input values fall within the 0 to 1 range.
/// </summary>
internal class Normalization : IFunction
{
    private double min;

    private double max;

    public double Output(double value) => max == 0 || min == 0 ? 0 : (value - min) / (max - min);

    public void Setup(double[] inputs) => (min, max) = (inputs.Min(), inputs.Max());
}
