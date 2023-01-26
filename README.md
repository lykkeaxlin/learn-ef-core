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

## `DbContext.cs`:

Add `Èntity` to `DbContext`

```
public DbSet<Genre> Genres { get; set; }
```

# Configuring relationships

## Many-to-many

```
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
    public ICollection<BookCategory> BookCategories { get; set; }
}
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public ICollection<BookCategory> BookCategories { get; set; }
}
public class BookCategory
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```

And specify relationship:

```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<BookCategory>()
        .HasKey(bc => new { bc.BookId, bc.CategoryId });
    modelBuilder.Entity<BookCategory>()
        .HasOne(bc => bc.Book)
        .WithMany(b => b.BookCategories)
        .HasForeignKey(bc => bc.BookId);
    modelBuilder.Entity<BookCategory>()
        .HasOne(bc => bc.Category)
        .WithMany(c => c.BookCategories)
        .HasForeignKey(bc => bc.CategoryId);
}
```
