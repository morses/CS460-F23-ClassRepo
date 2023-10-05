using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HW1.Models;
using HW1.ViewModels;

namespace HW1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ScheduleViewModel svm = new ScheduleViewModel();
        return View(svm);
    }

    [HttpPost]
    public IActionResult Index(ScheduleViewModel vm)
    {
        if (ModelState.IsValid)
        {
            ScheduleFinder sf = new ScheduleFinder(vm.BusyTimes, vm.IncludeWeekends);
            vm.FreeTimes = sf.FreeTimes;
        }
        // This leaves the user on a POST, which is not great.  The alternative is to use a GET but this
        // means an annoyingly long URL with all the busy times in it.  It's a tradeoff.  A better solution
        // for this application would be to use JavaScript to do the POST asynchronously upon button press
        // and then update the page with the results.
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
