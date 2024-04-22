using Hypha.Enums;

namespace Hypha.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class OperationAttribute : Attribute
{
    public OperationAttribute(string version, OperationTypes operationTypes, ExecutionTypes executionTypes)
    {
        Version = version;
        OperationType = operationTypes;
        ExecutionTypes = executionTypes;
    }

    public string Version { get; set; }
    public OperationTypes OperationType { get; set; }
    public ExecutionTypes ExecutionTypes { get; set; }
}
