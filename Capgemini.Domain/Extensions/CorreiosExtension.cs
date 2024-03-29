﻿using Capgemini.Domain.Entities;

namespace Capgemini.Domain.Extensions
{
    public static class CorreiosExtension
    {

        public static EnderecoEntity GetZipCode(EnderecoEntity end)
        {
            var addresses = new Correios.NET.CorreiosService();

            EnderecoEntity endereco = new EnderecoEntity();
            foreach (var address in addresses.GetAddresses(end.Cep))
            {
                endereco.Cidade = address.City;
                endereco.Estado = address.State;
                endereco.Logradouro = address.Street;
                endereco.Bairro = address.District;
                endereco.Cep = address.ZipCode;
                endereco.Complemento = end.Complemento;
                endereco.Numero = end.Numero;

            }
            return endereco;
        }
    }
}