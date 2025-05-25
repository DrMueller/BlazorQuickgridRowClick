using BlazorApp1.Infrastructure.Data.Models;
using BlazorApp1.Models;
using BlazorApp1.Shared.QuickGrids.Filtering.Models;

namespace BlazorApp1.Services;

public interface IIndividualsService
{
    Task<IReadOnlyCollection<Individual>> SearchAsync(IndividualsSearch search);
}