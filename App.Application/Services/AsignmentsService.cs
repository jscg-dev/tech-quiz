using App.Application.Services.Schematics;
using App.Domain.Context;
using App.Domain.Entities;
using App.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services;

public class AsignmentsService : MainService<Asignment>
{
    public AsignmentsService(UContext db) : base(db) {}

    public override async Task<Asignment> Add(Asignment record)
    {
        int count = await _db
            .Set<Asignment>()
            .Where(db => db.CourseId == record.CourseId && db.StudentId == db.StudentId)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con el id del estudiante y de la materia");

        _db.Entry(record).State = EntityState.Added;
        await _db.SaveChangesAsync();

        return record;
    }

    public override async Task<Asignment> Update(Asignment record)
    {
        int count = await _db
            .Set<Asignment>()
            .Where(db => db.Id != record.Id && db.CourseId == record.CourseId && db.StudentId == db.StudentId)
            .CountAsync();

        if (count > 0) throw new RequestViolationException(HttpStatusCode.BadRequest, "ya existe un registro con el id del estudiante y de la materia");

        record.UpdatedDate = DateTime.UtcNow;
        _db.Entry(record).State = EntityState.Added;
        await _db.SaveChangesAsync();

        return record;
    }
}
