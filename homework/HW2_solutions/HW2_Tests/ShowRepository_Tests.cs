using HW2.DAL.Abstract;
using HW2.DAL.Concrete;
using HW2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HW2_Tests;

/// <summary>
/// No tests for this one, as we haven't discussed yet how to test code that uses the database.
/// </summary>

public class ShowRepository_Tests
{
    private Mock<StreamingDbContext> _mockContext;
    private Mock<DbSet<Show>> _mockShowDbSet;
    private List<Show> _shows;
    private List<ShowType> _showTypes;

    // a helper to make dbset queryable
    private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
        return mockSet;
    }


    [SetUp]
    public void Setup()
    {
        _showTypes = new List<ShowType>
        {
            new ShowType { Id = 1, ShowTypeIdentifier = "SHOW"},
            new ShowType { Id = 2, ShowTypeIdentifier = "MOVIE"}
        };

        _shows = new List<Show>
        {
            new Show { Id = 1, Title = "Show 1", ShowTypeId = 1, TmdbPopularity = 1.0, ImdbVotes = 1.0 },
            new Show { Id = 2, Title = "Show 2", ShowTypeId = 1, TmdbPopularity = 2.0, ImdbVotes = 2.0 },
            new Show { Id = 3, Title = "Show 3", ShowTypeId = 1, TmdbPopularity = 3.0, ImdbVotes = 3.0 },
            new Show { Id = 4, Title = "Show 4", ShowTypeId = 1, TmdbPopularity = 4.0, ImdbVotes = 4.0 },
            new Show { Id = 5, Title = "Show 5", ShowTypeId = 1, TmdbPopularity = 5.0, ImdbVotes = 5.0 },
            new Show { Id = 6, Title = "Show 6", ShowTypeId = 1, TmdbPopularity = 6.0, ImdbVotes = 6.0 },
            new Show { Id = 7, Title = "Show 7", ShowTypeId = 2, TmdbPopularity = 7.0, ImdbVotes = 7.0 },
            new Show { Id = 8, Title = "Show 8", ShowTypeId = 2, TmdbPopularity = 8.0, ImdbVotes = 8.0 },
            new Show { Id = 9, Title = "Show 9", ShowTypeId = 2, TmdbPopularity = 9.0, ImdbVotes = 9.0 },
            new Show { Id = 10, Title = "Show 10", ShowTypeId = 2, TmdbPopularity = 10.0, ImdbVotes = 10.0 },
            new Show { Id = 11, Title = "Show 11", ShowTypeId = 2, TmdbPopularity = 11.0, ImdbVotes = 11.0 },
            new Show { Id = 12, Title = "Show 12", ShowTypeId = 2, TmdbPopularity = 12.0, ImdbVotes = 12.0 }
        };

        // Set up the to-one navigation property in Show to ShowType
        _shows.ForEach(s => s.ShowType = _showTypes.Where(st => st.Id == s.ShowTypeId).FirstOrDefault());

        // Setu up the to-many navigation property in ShowType (not used in these tests)
        _showTypes.ForEach(st => st.Shows = _shows.Where(s => s.ShowTypeId == st.Id).ToList());

        _mockContext = new Mock<StreamingDbContext>();
        _mockShowDbSet = GetMockDbSet(_shows.AsQueryable());
        _mockContext.Setup(ctx => ctx.Shows).Returns(_mockShowDbSet.Object);
        _mockContext.Setup(ctx => ctx.Set<Show>()).Returns(_mockShowDbSet.Object);
    }

     [Test]
     public void NumberOfShowsByType_Returns_Expected_Counts()
     {
         // Arrange
         IShowRepository repo = new ShowRepository(_mockContext.Object);

         // Act
         var (numShows, numMovies, numTVs) = repo.NumberOfShowsByType();

         // Assert
         Assert.Multiple(() =>
         {
             Assert.That(numShows, Is.EqualTo(12));
             Assert.That(numMovies, Is.EqualTo(6));
             Assert.That(numTVs, Is.EqualTo(6));
         });
     }

    [Test]
    public void HighestTMDBPopularity_Returns_Show_With_HighestTMDBPopularity()
    {
        // Arrange
        IShowRepository repo = new ShowRepository(_mockContext.Object);

        // Act
        var show = repo.HighestTMDBPopularity();

        // Assert
        Assert.That(show.Id, Is.EqualTo(12));
    }

    [Test]
    public void MostIMDBVotes_Returns_Show_With_MostIMDBVotes()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);

        // Act
        var show = showRepo.MostIMDBVotes();

        // Assert
        Assert.That(show.Id, Is.EqualTo(12));
    }

    [Test]
    public void MaxTmdbPopularity_Returns_Max_TmdbPopularity()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);

        // Act
        var maxTmdbPopularity = showRepo.MaxTmdbPopularity();

        // Assert
        Assert.That(maxTmdbPopularity, Is.EqualTo(12.0));
    }

    [Test]
    public void MaxImdbVotes_Returns_Max_ImdbVotes()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);

        // Act
        var maxImdbVotes = showRepo.MaxImdbVotes();

        // Assert
        Assert.That(maxImdbVotes, Is.EqualTo(12.0));
    }

    [Test]
    public void GetShowTitlesByIds_For_3_IDs_Returns_Expected_Titles()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);
        var ids = new List<int> { 1, 2, 3 };

        // Act
        var titles = showRepo.GetShowTitlesByIds(ids);

        // Assert
        Assert.That(titles, Is.EqualTo(new List<string> { "Show 1", "Show 2", "Show 3" }));
    }

    [Test]
    public void GetShowTitlesByIds_For_0_IDs_Returns_Empty_List()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);
        var ids = new List<int>();

        // Act
        var titles = showRepo.GetShowTitlesByIds(ids);

        // Assert
        Assert.That(titles, Is.EqualTo(new List<string>()));
    }

    [Test]
    public void GetShowTitlesByIds_For_Random_IDs_Returns_Expected_Titles_Ordered_Alphabetically()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);
        var ids = new List<int> { 7, 3, 5, 2, 4, 10 };

        // Act
        var titles = showRepo.GetShowTitlesByIds(ids);

        // Assert
        Assert.That(titles, Is.EqualTo(new List<string> { "Show 10", "Show 2", "Show 3", "Show 4", "Show 5", "Show 7" }));
    }

    [Test]
    public void GetShowTitlesByIds_For_Duplicate_Ids_Returns_Expected_Titles_With_NO_Duplicates_In_Order()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);
        var ids = new List<int> { 7, 3, 5, 2, 4, 10, 7, 3, 5, 2, 4, 10 };

        // Act
        var titles = showRepo.GetShowTitlesByIds(ids);

        // Assert
        Assert.That(titles, Is.EqualTo(new List<string> { "Show 10", "Show 2", "Show 3", "Show 4", "Show 5", "Show 7" }));
    }

    [Test]
    public void GetShowTitlesByIds_For_Ids_That_Dont_Exist_Returns_Empty_List()
    {
        // Arrange
        IShowRepository showRepo = new ShowRepository(_mockContext.Object);
        var ids = new List<int> { 13, 14, 15 };

        // Act
        var titles = showRepo.GetShowTitlesByIds(ids);

        // Assert
        Assert.That(titles, Is.EqualTo(new List<string>()));
    }   
    
}