using System.Linq.Expressions;

namespace Lanre.Module.Poll.Infrastructure.Converters
{
    internal static class StringConverters
    {
        internal static class StringListConverter
        {
            internal static Expression<Func<string, List<string>>> From = v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            internal static Expression<Func<List<string>, string>> To = v => string.Join(',', v);
        }
    }
}
