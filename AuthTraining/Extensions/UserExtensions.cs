using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Contracts.Models;

namespace WeatherForecastApi.Extensions
{
    public static class UserExtensions
    {
        public static IActionResult ToActionResult(this User user)
        {
            if (user == null)
                new NotFoundResult();

            return new OkObjectResult(user);
        }
    }
}
