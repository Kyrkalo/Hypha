using Hypha.Enums;

namespace Hypha.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class OperationAttribute : Attribute
{
    public OperationAttribute(string version, ExecutionTypes executionTypes)
    {
        Version = version;
        ExecutionTypes = executionTypes;
    }

    public string Version { get; set; }
    public ExecutionTypes ExecutionTypes { get; set; }
}
