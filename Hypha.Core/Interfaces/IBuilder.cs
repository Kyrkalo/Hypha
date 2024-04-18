using Hypha.Records;

namespace Hypha.Interfaces;

internal interface IBuilder<T>
{
    IBuilder<T> Setup(Setup setup);

    T Build();
}
