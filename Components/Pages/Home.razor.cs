namespace BlazorApp1.Components.Pages;

public partial class Home
{
    private IQueryable<Person> Query { get; set; } = new List<Person>().AsQueryable();
    private int SelectedId { get; set; }

    protected override void OnInitialized()
    {
        Query = new List<Person>
        {
            new(1, "John Doe"),
            new(2, "John Doe 2"),
            new(3, "John Doe 3"),
            new(4, "John Doe 4")
        }.AsQueryable();
    }

    private void HandleRowClickedAsync(string id)
    {
        SelectedId = int.Parse(id);
    }
}