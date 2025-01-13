namespace Hypha.Interfaces;

internal interface ILoss
{
    double Execute(double[] output, double[] target);
}
