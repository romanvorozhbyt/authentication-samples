using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Data.NewFolder;
using WeatherForecastApi.Extensions;

namespace WeatherForecastApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        public AdminController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public IActionResult GetUser(string userName)
        {
            var user = _userProvider.GetByName(userName);
            
            return user.ToActionResult();
        }
    }
}