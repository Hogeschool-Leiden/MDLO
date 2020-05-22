using Microsoft.EntityFrameworkCore;

public class ModuleDomeinContext : DbContext
{
    public DbSet<DomeinModule> DomeinModules { get; set; }
	public ModuleDomeinContext(DbContextOptions<ModuleDomeinContext> options) : base(options)
	{

	}
}
