using HealthMed.Domain.Entities;
using HealthMed.Domain.Enums;
using HealthMed.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Infrastructure.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        HealthMedDbContext _context;
        public PersonRepository(HealthMedDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var result = await _context.Persons
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Person>> GetAllByPersonType(EPersonType personType)
        {
            var result = await _context.Persons
                .Where(x => x.PersonType == personType)
                .ToListAsync();

            return result;
        }

        public async Task<Person> Insert(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public async Task Update(Person person)
        {
            await Task.Run(() => _context.Persons.Update(person));
            await _context.SaveChangesAsync();
        }
    }
}
