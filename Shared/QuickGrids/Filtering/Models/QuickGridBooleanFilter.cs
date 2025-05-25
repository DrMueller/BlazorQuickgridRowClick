namespace BlazorApp1.Shared.QuickGrids.Filtering.Models
{
    public class QuickGridBooleanFilter : QuickGridFilter<bool?>
    {
        protected override bool IsFilterSet => Value != null;

        public override bool ApplyFilter(bool? value)
        {
            if (!IsFilterSet || value == null)
            {
                return true;
            }

            return value == Value;
        }
    }
}