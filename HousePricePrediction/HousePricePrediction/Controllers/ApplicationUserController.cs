using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousePricePrediction.Models;
using HousePricePrediction.Data;

namespace HousePricePrediction.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationUserController : ControllerBase
    {

        private readonly ILogger<ApplicationUserController> _logger;
        private readonly IRepository<ApplicationUser> _userRepository;

        public ApplicationUserController(ILogger<ApplicationUserController> logger, IRepository<ApplicationUser> repository)
        {
            _logger = logger;
            _userRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }
    }
}
