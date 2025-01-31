﻿using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class CreateUserService : ICreateUserService
    {
        private readonly IUpdateUserService _updateUserService;
        private readonly IIdObjectFactory<User> _userFactory;
        private readonly IUserRepository _userRepository;

        public CreateUserService(IIdObjectFactory<User> userFactory, IUserRepository userRepository, IUpdateUserService updateUserService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _updateUserService = updateUserService;
        }

        public User Create(string name, string email, UserTypes type, int? age, decimal? annualSalary, IEnumerable<string> tags)
        {
            var id = Guid.NewGuid();

            var user = _userFactory.Create(id);
            _updateUserService.Update(user, name, email, type, age, annualSalary, tags);
            _userRepository.Save(user);
            return user;
        }
    }
}