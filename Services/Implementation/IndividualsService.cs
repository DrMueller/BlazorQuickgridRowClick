using BlazorApp1.Infrastructure.Data.DbContexts.Factories.Implementation;
using BlazorApp1.Infrastructure.Data.Models;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services.Implementation;

public class IndividualsService : IIndividualsService
{
    public async Task<IReadOnlyCollection<Individual>> SearchAsync(IndividualsSearch search)
    {
        var appDbContext = AppDbContextFactory.Create();
        var individuals = appDbContext.Set<Individual>().AsQueryable();

        if (!string.IsNullOrEmpty(search.FirstName))
            individuals = individuals.Where(i => i.FirstName.Contains(search.FirstName));

        if (search.BirthDate.HasValue)
            individuals = individuals.Where(f => f.BirthDate.Date == search.BirthDate.Value.Date);

        return await individuals.ToListAsync();
    }
}