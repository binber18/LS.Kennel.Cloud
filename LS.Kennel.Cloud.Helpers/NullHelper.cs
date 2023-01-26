using System.Runtime.CompilerServices;

namespace LS.Kennel.Cloud.Helpers;

public static class NullHelper
{
    public static T AssertNotNull<T>(this T? param, [CallerArgumentExpression(nameof(param))] string? paramName = null) => param ?? throw new ArgumentNullException(paramName);
}