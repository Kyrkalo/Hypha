using Hypha.Attributes;
using Hypha.Enums;
using System.Reflection;

namespace Hypha.Extensions;

internal static class OperationExtensions
{
    public static T CreateOperation<T>(string version, ExecutionTypes executionType)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                var attribute = type.GetCustomAttribute<OperationAttribute>();
                if (attribute != null && attribute.Version == version && attribute.ExecutionTypes == executionType)
                {
                    return (T)Activator.CreateInstance(type);
                }
            }
        }
        return default;
    }
}
