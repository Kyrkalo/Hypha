using Hypha.Records;

namespace Hypha.Interfaces;

internal interface IBuilder<T>
{
    void Setup(Setup setup);

    T Build();
}
