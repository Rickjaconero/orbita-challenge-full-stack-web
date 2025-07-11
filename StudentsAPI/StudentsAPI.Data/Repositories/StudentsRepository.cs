﻿using Microsoft.EntityFrameworkCore;
using StudentsAPI.Data.Abstractions;
using StudentsAPI.Data.Abstractions.Repositories;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Repositories
{
    internal sealed class StudentsRepository : IStudentsRepository
    {
        private readonly IApplicationContext _context;

        public StudentsRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await _context.Students
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student> GetByAcademicRegistryAsync(Guid academicRegistry)
        {
            var student = await _context.Students
                .SingleAsync(x => x.AcademicRegistry == academicRegistry);

            return student;
        }

        public async Task<IEnumerable<Student>> GetByNameAsync(string name)
        {
            var students = _context.Students
                .AsNoTracking()
                .Where(x => x.Name.ToUpper().Contains(name.ToUpper()));

            return await students.ToListAsync();
        }

        public async Task<bool> IsCpfAlreadyRegisteredAsync(string cpf)
        {
            return await _context.Students
                .AsNoTracking()
                .AnyAsync(x=> x.Cpf == cpf);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public void Remove(Student student)
        {
            _context.Students.Remove(student);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}