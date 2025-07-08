using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Configurations
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(p => p.AcademicRegistry);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Cpf).IsRequired().HasMaxLength(11);
        }
    }
}