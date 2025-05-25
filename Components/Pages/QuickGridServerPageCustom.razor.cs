using BlazorApp1.Infrastructure.Data.Models;
using BlazorApp1.Models;
using BlazorApp1.Services;
using BlazorApp1.Shared.QuickGrids.Filtering.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace BlazorApp1.Components.Pages;

public partial class QuickGridServerPageCustom
{
    private readonly PaginationState pagination = new() { ItemsPerPage = 10 };

    [Inject] public required IIndividualsService IndividualsService { get; set; }

    private IQueryable<Individual> Individuals { get; set; } = new List<Individual>().AsQueryable();

    private QuickGridStringFilter FirstNameFilter { get; } = QuickGridFilter.CreateForString();

    private QuickGridDateFilter BirthdateFilter { get; } = QuickGridFilter.CreateForDate();

    private async Task Click()
    {
        var val = await IndividualsService.SearchAsync(new IndividualsSearch(
            FirstNameFilter.Value,
            BirthdateFilter.Value));

        Individuals = val.AsQueryable();
    }
}