namespace Hypha.Interfaces;

internal interface IFunction
{
    double Output(double input);

    void Setup(double[] inputs);
}
