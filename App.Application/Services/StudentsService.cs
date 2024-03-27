using App.Application.Services.Schematics;
using App.Domain.Context;
using App.Domain.Entities;
using App.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace App.Application.Services;

public class StudentsService : MainService<Students>
{
    public StudentsService(UContext db) : base(db)
    {
    }

    public override async Task<Students> Add(Students record)
    {
        int count = await _db
            .Set<Students>()
            .Where(db => db.Dni == record.Dni)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con las indicaciones");

        _db.Entry(record).State = EntityState.Added;
        await _db.SaveChangesAsync();

        return record;
    }

    public override async Task<Students> Update(Students record)
    {
        int count = await _db
            .Set<Students>()
            .Where(db => db.Dni == record.Dni && db.Id != record.Id)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con las indicaciones");
        record.UpdatedDate = DateTime.UtcNow;
        _db.Entry(record).State = EntityState.Added;
        await _db.SaveChangesAsync();

        return record;
    }
}
