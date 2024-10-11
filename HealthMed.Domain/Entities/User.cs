using HealthMed.Shared.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public static User Create(string password, Person person)
        {
            return new User()
            {
                UserName = person.Email,
                Password = PasswordHasher.HashSHA256(password),
                Person = person,
                ProfileId = 1,
            };
        }
    }
}
