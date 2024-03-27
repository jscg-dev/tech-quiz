using App.Domain.Context.Attributes;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic;
using System.Linq;
using System.Reflection;

namespace App.Domain.Context;
/// <summary>
///     DbContext for institution
/// </summary>
public class UContext : DbContext
{
    public UContext(DbContextOptions opt) : base(opt) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new DefaultSetterConvention());
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder _)
    {
        _.Entity<Asignment>(_e =>
        {
            _e.ToTable("asignments");
            _e.HasIndex(__ => new
            {
                __.CourseId,
                __.StudentId
            })
            .IsUnique(true);

            _e.HasOne(__ => __.Course)
            .WithMany(__ => __.Asignments)
            .OnDelete(DeleteBehavior.NoAction);

            _e.HasOne(__ => __.Student)
            .WithMany(__ => __.Groups)
            .OnDelete(DeleteBehavior.NoAction);
        })
        .Entity<Course>(_e =>
        {
            _e.ToTable("courses");
            _e.HasIndex(__ => new
            {
                __.Name,
                __.GroupId
            })
            .IsUnique(true);

            _e.HasOne(__ => __.Group)
            .WithMany(__ => __.Courses)
            .OnDelete(DeleteBehavior.NoAction);
        })
        .Entity<Mark>(_e =>
        {
            _e.ToTable("marks");
            _e.HasIndex(__ => __.AsigmentId)
            .IsUnique(true);
            _e.HasOne(__ => __.Asignment)
            .WithOne(__ => __.Mark)
            .OnDelete(DeleteBehavior.NoAction);
        })
        .Entity<Students>(_e =>
        {
            _e.ToTable("students");
            _e.HasIndex(__ => __.Dni)
            .IsUnique(true);
        })
        .Entity<User>(_e =>
        {
            _e.ToTable("users");
            _e.HasIndex(__ => __.Username)
            .IsUnique(true);
        })
        .Entity<Group>(_e =>
        {
            _e.ToTable("groups");
            _e.HasIndex(__ => __.Name).IsUnique(true);
        });
    }
}
/// <summary>
///     Convention to add Default constraint setted on the property columns
///     attribute <see cref="DefaultConstraintAttribute"/>
/// </summary>
public class DefaultSetterConvention : IModelFinalizingConvention
{
    /// <summary>
    ///     Convention to add Default constraint setted on the property columns
    ///     attribute <see cref="DefaultConstraintAttribute"/>
    /// </summary>
    public DefaultSetterConvention() { }
    public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
    {
        modelBuilder
            .Metadata
            .GetEntityTypes()
            .SelectMany(_t => _t
                .GetDeclaredProperties()
                .Where(_props => _props.PropertyInfo?.CustomAttributes.Any(_ett => _ett.AttributeType == typeof(DefaultConstraintAttribute)) ?? false)
            )
            .ToList()
            .ForEach(_t =>
            {
                _t.Builder.HasDefaultValueSql(_t.PropertyInfo!.GetCustomAttribute<DefaultConstraintAttribute>()!.Expression);
            });
    }
}