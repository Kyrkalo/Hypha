using Hypha.Enums;

namespace Hypha.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
internal class BuilderAttribute : Attribute
{
    public BuilderAttribute(string version, OperationTypes operationTypes)
    {
        Version = version;
        OperationType = operationTypes;
    }

    public string Version { get; set; }
    public OperationTypes OperationType { get; set; }
}
