using BlazorApp1.Infrastructure.Data.Models.Base;

namespace BlazorApp1.Infrastructure.Data.Models;

public class Individual : Entity
{
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Length { get; set; }
}