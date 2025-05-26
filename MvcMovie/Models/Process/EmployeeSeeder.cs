using System;
using System.Collections.Generic;
using Bogus;
using MvcMovie.Models.Entities;
using MvcMovie.Data;

namespace MvcMovie.Models.Process
{
    public class EmployeeSeeder
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedEmployee2s(int n)
        {
            var employees = GenerateEmployee2s(n);
            _context.Employee2s.AddRange(employees);
            _context.SaveChanges();
        }

        private List<Employee2> GenerateEmployee2s(int n)
        {
            var faker = new Faker<Employee2>()
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.Address, f => f.Address.FullAddress())
                .RuleFor(e => e.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-20)))
                .RuleFor(e => e.Position, f => f.Name.JobTitle())
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                .RuleFor(e => e.HireDate, f => f.Date.Past(10));

            return faker.Generate(n);
        }
    }
}
