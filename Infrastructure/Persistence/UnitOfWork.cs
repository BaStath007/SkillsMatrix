using Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ISkillsMatrixDbContext _context;

    public UnitOfWork(SkillsMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        var number = await _context.SaveChangesAsync(cancellationToken);
        return number;
    }
}
