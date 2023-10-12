using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HW2.Models;
using HW2.DAL.Abstract;
using HW2.DAL.Concrete;
using HW2.ViewModels;
using NuGet.Protocol.Core.Types;
using NuGet.Packaging.Core;

namespace HW2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IShowRepository _showRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IRepository<Person> _personRepository;

    public HomeController(ILogger<HomeController> logger, IShowRepository showRepo, IGenreRepository genreRepo, IRoleRepository roleRepo, IRepository<Person> personRepo)
    {
        _logger = logger;
        _showRepository = showRepo;
        _genreRepository = genreRepo;
        _roleRepository = roleRepo;
        _personRepository = personRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Info()
    {
        InfoVM vm = new InfoVM();
        var (showCount, movieCount, tvCount) = _showRepository.NumberOfShowsByType();
        vm.NumberOfShows = showCount;
        vm.NumberOfMovies = movieCount;
        vm.NumberOfTVShows = tvCount;
        vm.ShowWithMostIMDBVotes = _showRepository.MostIMDBVotes();
        vm.ShowWithHighestTMDBPopularity = _showRepository.HighestTMDBPopularity();
        vm.Genres = _genreRepository.GenreNames();
        var (id, shows) = _roleRepository.DirectorWithTheMostShows();

        Person director = _personRepository.FindById(id);

        vm.DirectorNameWithMostShows = director?.FullName ?? "--No Director Found--";
        // sort list of strings alphabetically
        vm.ShowsForDirectorWithMost = _showRepository.GetShowTitlesByIds(shows);
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
