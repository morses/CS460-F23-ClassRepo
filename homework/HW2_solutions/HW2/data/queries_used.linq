<Query Kind="Statements">
  <Connection>
    <ID>e9b1ffe5-031f-4be9-b44f-c3205d080161</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\Repositories\regulardev\CS460_F23\HW2\HW2\bin\Debug\net7.0\HW2.dll</CustomAssemblyPathEncoded>
    <CustomTypeName>HW2.Models.StreamingDbContext</CustomTypeName>
    <CustomCxString>Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Streaming;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False</CustomCxString>
    <DriverData>
      <UseDbContextOptions>true</UseDbContextOptions>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

// # of shows
int numberOfShows = Shows.Count();
int numberOfMovies = Shows.Where(s => s.ShowType.ShowTypeIdentifier == "MOVIE").Count();
int numberOfTVShows = Shows.Where(s => s.ShowType.ShowTypeIdentifier == "SHOW").Count();
// Most popular shows
Show mostPopularTMDB = Shows.OrderBy(s => s.TmdbPopularity).Last();
Show mostPopularIMDB = Shows.OrderByDescending(s => s.ImdbVotes).First();
// Show with the largest cast
var largestCast = Shows.Select(s => new {Show = s, CastSize = s.Credits.Count()}).OrderByDescending(sc => sc.CastSize);
// Director with the most shows
//IGrouping<int,Credit> directorWithMostShows = Roles.First(r => r.RoleName == "DIRECTOR").Credits.GroupBy(c => c.Person.Id).OrderByDescending(gp => gp.Count()).First();
//directorWithMostShows.Dump();
//var directorData = new {Director = directorWithMostShows.First().Person.FullName, Count = directorWithMostShows.Count(), Shows = directorWithMostShows.Select(g => g.Show.Title)};
//directorData.Dump();

var directorShows = Roles.First(r => r.RoleName == "DIRECTOR")
						 .Credits
						 .GroupBy(c => c.Person.Id)
						 .OrderByDescending(gp => gp.Count())
						 .First()
						 .Select( g => new {Director = g.Person.FullName, Show = g.Show} );
directorShows.Dump();

// List of Genres, better way
Genres.Select(g => g.GenreString).Dump();

var ds = Roles.First(r => r.RoleName == "DIRECTOR")
						 .Credits
						 .Select(c => new {ShowId = c.ShowId, PersonId = c.PersonId})
						 .GroupBy(c => c.PersonId)
						 .OrderByDescending(gp => gp.Count())
						 .First();
ds.Dump();
Console.WriteLine(ds.Key);