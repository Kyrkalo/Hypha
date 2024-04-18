namespace Hypha.Interfaces;

public interface IFunction
{
    double Output(double input);

    void Setup(double[] inputs);
}
