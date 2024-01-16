using Colegio.Models;
using Microsoft.EntityFrameworkCore;

namespace Colegio
{
    public class ColegioContext : DbContext, IColegioContext
    {
        public DbSet<EstudentDto> Estudents { get; set; }

        public DbSet<GradeDto> Grades { get; set; }

        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<GradeDto> GradesInit = new()
            {
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Primero", Number = 1},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Segundo", Number = 2},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Tercero", Number = 3},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Cuarto", Number = 4},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Quinto", Number = 5},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Sexto", Number = 6},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Septimo", Number = 7},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Octavo", Number = 8},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Noveno", Number = 9},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Decimo", Number = 10},
                new GradeDto(){ Id = Guid.NewGuid(), Name = "Once", Number = 11},
            };
            modelBuilder.Entity<EstudentDto>(estudent =>
            {
                estudent.ToTable("Estudent");
                estudent.HasKey(x => x.Id);
                estudent.Property(x => x.Name).IsRequired().HasMaxLength(50);
                estudent.Property(x => x.Email).IsRequired().HasMaxLength(100);
                estudent.Property(x => x.TypeIdentification).IsRequired();
                estudent.Property(x => x.Identification).IsRequired();
                estudent.Property(x => x.GradeId).IsRequired();
            });

            modelBuilder.Entity<GradeDto>(grade =>
            {
                grade.ToTable("Grade");
                grade.HasKey(x => x.Id);
                grade.Property(x => x.Name).IsRequired().HasMaxLength(50);
                grade.Property(x => x.Number).IsRequired().HasMaxLength(20);
                grade.HasData(GradesInit);
            });
            modelBuilder.Entity<RegistrationDto>(registration =>
            {
                registration.ToTable("Registration");
                registration.HasKey(x => x.Id);
                registration.Property(x => x.StudentIdentification).IsRequired().HasMaxLength(50);
                registration.Property(x => x.Institution).IsRequired();
                registration.Property(x => x.City).IsRequired();
                registration.Property(x => x.GradeId).IsRequired();
                registration.Property(x => x.StudentId).IsRequired();
            });
            modelBuilder.Entity<TeacherDto>(teacher =>
            {
                teacher.ToTable("Teacher");
                teacher.HasKey(x => x.Id);
                teacher.Property(x => x.Name).IsRequired().HasMaxLength(50);
                teacher.Property(x => x.Email).IsRequired().HasMaxLength(100);
                teacher.Property(x => x.TypeIdentification).IsRequired();
                teacher.Property(x => x.Identification).IsRequired();
                teacher.Property(x => x.GradeId).IsRequired();
            });
        }

        void IColegioContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
