using Hypha.Attributes;
using Hypha.Enums;
using System.Reflection;

namespace Hypha.Extensions;

internal static class BuilderExtensions
{
    public static T CreateBuilder<T>(this Builder builder, string version, OperationTypes operation) where T : class
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                var attribute = type.GetCustomAttribute<BuilderAttribute>();
                if (attribute != null && attribute.Version == version && attribute.OperationType == operation)
                {
                    return (T)Activator.CreateInstance(type);
                }
            }
        }
        return default;
    }
}
