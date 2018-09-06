using System.Collections.Generic;
using System.Linq;

namespace Game.RockPaperScissors.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool ContainsValue<TType>(this IEnumerable<TType> list)
        {
            return (list != null && list.Any());
        }
    }
}