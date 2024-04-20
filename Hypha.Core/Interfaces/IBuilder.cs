using Hypha.Records;

namespace Hypha.Interfaces;

internal interface IBuilder<T>
{
    T Build(Setup setup);
}
