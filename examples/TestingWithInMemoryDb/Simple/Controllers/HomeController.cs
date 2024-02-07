using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Reflection.PortableExecutable;
using Simple.Areas.Identity.Data;
using Simple.DAL.Abstract;
using Simple.Models;

namespace Simple.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserLogRepository _userLogger;
    private readonly UserManager<SimpleUser> _userManager;

    public HomeController(ILogger<HomeController> logger, IUserLogRepository userLogger, UserManager<SimpleUser> userManager)
    {
        _logger = logger;
        _userLogger = userLogger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        // Get the current user's id or null
        string id = _userManager.GetUserId(User);

        // Log this visit
        UserLog lg = new UserLog
        {
            AspnetIdentityId = id,
            TimeStamp = DateTime.UtcNow,
            Ipaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            UserAgent = Request.Headers.UserAgent,
            // Pick a random color between 1 and 3 (should be between 1 and max color count)
            ColorId = new Random().Next(1, 4)
        };
        _userLogger.AddOrUpdate(lg);

        MainPageVM vm = new MainPageVM();

        // To get details of the user stored in the Identity tables, use an Identity provided manager, such as UserManager
        SimpleUser user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.HasUser = true;
            var logs = _userLogger.MostRecentVisit(id, 2);
            if (logs.Count() == 2)
            {
                vm.SetVisitTimes(logs[1].TimeStamp, DateTime.UtcNow);
            }
        }

        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
