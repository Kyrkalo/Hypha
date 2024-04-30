namespace Hypha.Interfaces;

public interface IFunction
{
    double Activate(double input);

    double Backward(double input);

    void Setup(double[] inputs);
}
