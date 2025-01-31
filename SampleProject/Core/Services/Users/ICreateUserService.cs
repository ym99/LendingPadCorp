﻿using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Users
{
    public interface ICreateUserService
    {
        User Create(string name, string email, UserTypes type, int? age, decimal? annualSalary, IEnumerable<string> tags);
    }
}