using BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Infrastructure;

public class AppDbContext(/*ILoggerFactory loggerFactory*/) : DbContext, IUnitOfWork
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseLoggerFactory(loggerFactory).EnableSensitiveDataLogging();
    }

    async Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }
}
