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
    public class TodosController : Controller
    {
        private readonly TodoRepository _todoRepository;
            
        public TodosController(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [Route("get-all")]
        public Task<string> GetAll()
        {
            return _todoRepository.GetAll();
        }
    }
}
