using App.Domain.Context;
using App.Domain.Entities.Application;
using App.Domain.Entities.Schematics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace App.Application.Services.Schematics;

public abstract class MainService<TSet> where TSet : DbMainTable
{
    protected readonly UContext _db;

    public MainService(UContext db)
    {
        _db = db;
    }

    public abstract Task<TSet> Add(TSet record);
    public async Task<TSet?> Get(int id) => await _db.Set<TSet>().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<ResponsePage<TSet>> Page(int regs, int page, Expression<Func<TSet, bool>> predicate)
    {
        int totalrecords = await _db
            .Set<TSet>()
            .Where(predicate)
            .CountAsync();

        if (totalrecords == 0) throw new RequestViolationException(HttpStatusCode.NotFound, string.Empty);

        decimal totalpages = Math.Ceiling((decimal)totalrecords / regs);

        IEnumerable<TSet> records = await _db
            .Set<TSet>()
            .Where(predicate)
            .OrderBy(db => db.Id)
            .Skip((page - 1) * regs)
            .Take(regs)
            .ToListAsync();

        return new()
        {
            Prev = page == 1 ? null : page - 1,
            TotalPages = (int)totalpages,
            Next = (int)totalpages == page ? null : page + 1,
            Regs = regs,
            Result = records
        };
    }

    public async Task Remove(int id)
    {
        TSet? record = await _db.Set<TSet>().FirstOrDefaultAsync(x => x.Id == id);

        if (record == null) throw new RequestViolationException(HttpStatusCode.NotFound);

        _db.Entry(record).State = EntityState.Deleted;
        await _db.SaveChangesAsync();
    }
    public abstract Task<TSet> Update(TSet record);
}
