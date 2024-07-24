using System.Reflection;

namespace WebApi.Shared.Services.ReflectionService;

public interface IReflectionService
{
    IEnumerable<Type> GetClassTypes<T>(Assembly assembly);
}