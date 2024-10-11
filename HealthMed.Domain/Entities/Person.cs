using HealthMed.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CRM { get; set; }
        public EPersonType PersonType { get; set; }
        public static Person Create(string name, string cpf, string email, EPersonType personType, string? crm)
        {
            return new Person()
            {
                Name = name,
                CPF = cpf,
                Email = email,
                PersonType = personType,
                CRM = crm
            };
        }
    }
}
