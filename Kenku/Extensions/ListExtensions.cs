namespace Kenku.Extensions
{
    public static class ListExtensions
    {
        private static Random RandomSeed { get; } = new Random();
        public static T SelectRandomItem<T>(this IEnumerable<T> items, Func<T, bool>? selector = null)
        {
            if (items == null || !items.Any())
            {
                throw new Exception("items must not be null or empty");
            }
            if (selector != null)
            {
                items = items
                    .Where(selector);
            }
            var index = ListExtensions
                .RandomSeed
                .Next(0, items.Count() - 1);
            return items
                .ElementAt(index);
        }

        public static T FirstOrDefaultFallbackFirst<T>(this IEnumerable<T> items, Func<T, bool> selector)
        {
            var output = items
                .FirstOrDefault(selector) ?? items
                .First();
            return output;
        }

        public static T FirstOrDefaultFallbackFirst<T>(this IEnumerable<T> items, string? name, Func<T, string> nameSelector)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return items
                    .First();
            }
            var output = items
                .FirstOrDefaultFallbackFirst(x => string.Equals(nameSelector(x), name, StringComparison.OrdinalIgnoreCase));
            return output;
        }
    }
}