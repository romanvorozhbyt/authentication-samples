using System;
using System.Collections.Generic;
using WeatherForecast.Contracts.Models;

namespace WeatherForecast.Data.NewFolder
{
    public interface IUserProvider
    {
        public IEnumerable<User> GetAll();
        public User GetByName(string userName);
        public IEnumerable<User> Search(Func<User, bool> predicate);
    }
}