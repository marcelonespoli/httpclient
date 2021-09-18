using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;
            
        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("get-all")]
        public Task<string> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
