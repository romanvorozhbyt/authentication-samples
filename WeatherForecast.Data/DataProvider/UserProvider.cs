﻿using System;
using System.Collections.Generic;
using System.Linq;
using WeatherForecast.Data.Models;

namespace WeatherForecast.Data.NewFolder
{
    internal class UserProvider : IUserProvider
    {
        private List<User> appUsers = new List<User>
        {
            new User { FullName = "admin", UserName = "admin", Password = "1234", UserRole = "Admin" },
            new User { FullName = "Test User", UserName = "user", Password = "1234", UserRole = "User" }
        };

        public IEnumerable<User> GetAll()
        {
            return appUsers;
        }

        public IEnumerable<User> Search(Func<User, bool> predicate)
        {
            return appUsers.Where(predicate);
        }
    }
}