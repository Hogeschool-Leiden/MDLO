using CompetentieAppFrontend.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace CompetentieAppFrontend.Infrastructure.Test
{
    internal class TestHelpers
    {
        internal static void InjectData<T>(DbContextOptions<CompetentieAppFrontendContext> options, params T[] entities)
            where T : class
        {
            using var context = new CompetentieAppFrontendContext(options);
            context.Set<T>().AddRange(entities);
            context.SaveChanges();
        }
    }
}