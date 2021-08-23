using Capgemini.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Domain.Entities
{
    public class EnderecoEntity
    {
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Logradouro { get; set; }

    }
}
