﻿using System;
using System.Collections.Generic;
using WeatherForecast.Data.Models;

namespace WeatherForecast.Data.NewFolder
{
    public interface IUserProvider
    {
        public IEnumerable<User> GetAll();
        public IEnumerable<User> Search(Func<User, bool> predicate);
    }
}