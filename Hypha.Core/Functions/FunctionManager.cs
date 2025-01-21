using Hypha.Functions.Interfaces;
using Hypha.Functions.Loss;

namespace Hypha.Functions;

internal class FunctionManager
{
    private readonly Dictionary<string, IFunction> _functions = new Dictionary<string, IFunction>();

    public FunctionManager()
    {
        RegisterFunctions();
    }

    private void RegisterFunctions()
    {
        AddFunction(new LeakyReLU());
        AddFunction(new LinearTransform());
        AddFunction(new ReLU());
        AddFunction(new Normalization());
        AddFunction(new CrossEntropy());
        AddFunction(new Softmax());
        AddFunction(new MeanSqueredError());
        AddFunction(new Sigmoid());
        AddFunction(new Tanh());
    }

    private void AddFunction(IFunction function)
    {
        _functions[function.GetType().Name] = function;
    }

    public IEnumerable<T> GetGroupFunctions<T>()
    {
        var result = _functions.Values.Where(e => e is T).Select(e => (T)e);
        return result;
    }
}
