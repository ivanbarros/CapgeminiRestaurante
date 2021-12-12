using Capgemini.Domain.Entities;
using System;

namespace Capgemini.Domain.DTOs
{
    public class WaiterDTO
    {
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public EnderecoEntity Endereco { get; set; }
        public string Cpf { get; set; }
    }
}
