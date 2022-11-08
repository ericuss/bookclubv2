using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lanre.Module.Poll.Infrastructure.Comparers
{
    internal static class StringComparers
    {
        internal static ValueComparer<List<string>> StringListComparer = new ValueComparer<List<string>>(
            (c1, c2) => (c1 ?? new List<string>()).SequenceEqual(c2 ?? new List<string>()),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
    }
}
