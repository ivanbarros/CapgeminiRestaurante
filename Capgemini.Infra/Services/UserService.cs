using Capgemini.Domain.Entities;
using Capgemini.Domain.Extensions;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capgemini.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public async Task<UserEntity> Add(UserEntity entity)
        {
             CorreiosExtension.GetZipCode(entity.Endereco);
            return entity;
        }

        public Task<IEnumerable<UserEntity>> Get(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
