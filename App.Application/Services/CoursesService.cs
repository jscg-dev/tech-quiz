using App.Application.Services.Schematics;
using App.Domain.Context;
using App.Domain.Entities;
using App.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace App.Application.Services;

public class CoursesService : MainService<Course>
{
    public CoursesService(UContext db) : base(db)
    {
    }

    public override async Task<Course> Add(Course record)
    {
        int count = await _db
            .Set<Course>()
            .Where(db => db.GroupId == record.GroupId && db.Name == db.Name)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con las indicaciones");

        _db.Entry(record).State = EntityState.Added;
        await _db.SaveChangesAsync();

        return record;
    }

    public override async Task<Course> Update(Course record)
    {
        int count = await _db
            .Set<Course>()
            .Where(db => db.GroupId == record.GroupId && db.Name == db.Name && db.Id != record.Id)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con las indicaciones");

        record.UpdatedDate = DateTime.UtcNow;
        _db.Entry(record).State = EntityState.Modified;
        await _db.SaveChangesAsync();

        return record;
    }
}
