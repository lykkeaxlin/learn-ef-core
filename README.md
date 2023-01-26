# learn-ef-core

## DB

![Skärmbild_20230126_101947](https://user-images.githubusercontent.com/46992305/214799981-8bcee50e-6f12-4816-a04c-c234190e5f13.png)

# Repository pattern

## `Core:`

`Interface:` Declare methods that should be implemented by corresponding repository, e.g.

```
public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetGenres();
}
```

## `Infra:`

`Repository:` Implementation of repository interfaces, e.g.

```
public class GenreRepository : IGenreRepository
{
    private readonly ApplicationDbContext context;

    public GenreRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Genre>> GetGenres()
    {
        var genres = await context.Genres
            .Include(x => x.Movies)
            .ToListAsync();
        return genres;
    }
}
```

## `UI`:

`Controllers:` Endpoints, use the repositories, e.g.

```
[ApiController]
[Route("api/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreRepository genreRepository;

    public GenreController(IGenreRepository genreRepository)
    {
        this.genreRepository = genreRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
    {
        try
        {
            var genres = await genreRepository.GetGenres();
            return Ok(genres);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
```

## `Program.cs`:

Don't forget dependency injection:

```
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
```
