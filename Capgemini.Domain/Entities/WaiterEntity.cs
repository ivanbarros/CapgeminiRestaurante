using Capgemini.Domain.Entities.Base;
using System;

namespace Capgemini.Domain.Entities
{
    public class WaiterEntity : BaseEntity
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string cpf;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private EnderecoEntity endereco;

        public EnderecoEntity Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private DateTime datebirth;

        public DateTime DateBirth
        {
            get { return datebirth; }
            set { datebirth = value; }
        }


    }
}
