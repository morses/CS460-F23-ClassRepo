using Microsoft.AspNetCore.Mvc;
using Simple.DAL.Abstract;
using Simple.Models;

namespace Simple.Controllers
{
    public class UserLogsController : Controller
    {
        private readonly IRepository<UserLog> _userLoggerRepository;

        public UserLogsController(IRepository<UserLog> userLoggerRepository)
        {
            _userLoggerRepository = userLoggerRepository;
        }

        // GET: UserLogs
        public IActionResult Index()
        {
              return View(_userLoggerRepository.GetAll().ToList());
        }

    }
}
