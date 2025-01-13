namespace Hypha.Interfaces;

internal interface IInput<T>
{
    T Model { get; set; }
    double[] In { get; set; }
    double[] Out { get; set; }
    double[] Target { get; set; }
}
