using System;

namespace Capgemini.Domain.Entities
{
    public class UserEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnderecoEntity Endereco { get; set; }
    }
}
