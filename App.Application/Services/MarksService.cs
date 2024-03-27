using App.Application.Services.Schematics;
using App.Domain.Context;
using App.Domain.Entities;
using App.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace App.Application.Services;

public class MarksService : MainService<Mark>
{
    public MarksService(UContext db) : base(db)
    {
    }

    public override async Task<Mark> Add(Mark record)
    {
        int count = await _db
            .Set<Mark>()
            .Where(db => db.AsigmentId == record.AsigmentId)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con las indicaciones");

        _db.Entry(record).State = EntityState.Added;
        await _db.SaveChangesAsync();

        return record;
    }

    public override async Task<Mark> Update(Mark record)
    {
        int count = await _db
            .Set<Mark>()
            .Where(db => db.AsigmentId == record.AsigmentId && db.Id != record.Id)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con las indicaciones");
        
        record.UpdatedDate = DateTime.UtcNow;
        _db.Entry(record).State = EntityState.Modified;
        await _db.SaveChangesAsync();

        return record;
    }
}
