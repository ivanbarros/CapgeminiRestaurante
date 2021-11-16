using Capgemini.Domain.Entities;
using Flunt.Validations;
using MediatR;
using System;

namespace Capgemini.Domain.Commands
{
    public class UserCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EnderecoEntity Endereco { get; set; }


        public UserCommand(string name, string lastName, string email, string cPF, DateTime dateOfBirth, EnderecoEntity endereco)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            CPF = cPF;
            DateOfBirth = dateOfBirth;
            Endereco = endereco;
            Validate();
        }
        public void Validate()
        {
            var flunt = new Contract<UserCommand>();

            flunt.Requires()

                .IsNotNullOrWhiteSpace(Name, "Name", "Favor informar Name.")
                .IsNotNullOrWhiteSpace(CPF, "CPF", "Favor informar CPF.");

            if (!flunt.IsValid)
                flunt.AddNotifications(flunt.Notifications);
        }
    }
}
