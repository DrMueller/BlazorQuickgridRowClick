namespace BlazorApp1.Shared.QuickGrids.Filtering.Models
{
    public class QuickGridFilters<T>
    {
        private readonly IReadOnlyCollection<QuickGridFilter<T>> _entries;

        public QuickGridFilters(IReadOnlyCollection<QuickGridFilter<T>> entries)
        {
            _entries = entries;
        }
    }
}
