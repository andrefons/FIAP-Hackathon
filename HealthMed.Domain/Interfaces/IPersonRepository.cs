﻿using HealthMed.Domain.Entities;
using HealthMed.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> Insert(Person person);
        Task Update(Person person);
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Person>> GetAllByPersonType(EPersonType personType);
    }
}
