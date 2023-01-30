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

Add `Entity` to `DbContext`

```
public DbSet<Genre> Genres { get; set; }
```

# Configuration relationships

`Principal key` - refers to the key (usually the primary key) in which entities are linked.

`Principal entity` - refers to the entity containing the principal key.

`Dependent entity` - refers to the entity that does not contain the principal key.

`Foreign key` - refers to the value of the primary key in the dependent entity.

`Navigation property` - refers to a property of an entity that linkes to other related entities.

`Required relationship` - refers to a relationship where the foreign key is not nullable. By default, when we delete the the principal entity, the dependent entities are deleted too.

`Optional relationship` - refers to a relationship where the foreign is nullable.

`Change from required to optional relationship`:

To prevent the dependent entities from being removed if the principal entity is deleted.

```
public class Cinema
{
    public int Id { get; set; }
    public HashSet<CinemaHall> CinemaHalls { get; set; }
}
```

```
public class CinemaHall
{
    public int Id { get; set; }
    public int? CinemaId { get; set; } // make the foreign key nullable
}
```

and include the dependent entities when deleting the principal entity:

```
public async Task<Cinema> DeleteCinemaById(int id)
{
    var cinemaToDelete = await context.Cinemas
                .Include(x => x.CinemaHalls) // IMPORTANT!
                .FirstOrDefaultAsync(x => x.Id == id);

    if (cinemaToDelete == null)
    {
        throw new ArgumentException($"Could not find Cinema with Id {id} to delete");
    }

    context.Remove(cinemaToDelete);
    await context.SaveChangesAsync();
    return cinemaToDelete;
}
```

## `one-to-one relationships`:

```
public class Cinema
{
    public int Id { get; set; }
    public CinemaOffer CinemaOffer { get; set; }
}
```

```
public class CinemaOffer
{
    public int Id { get; set; }
    public int CinemaId { get; set; } // foreign key
}
```

## `one-to-many relationships`:

```
public class Cinema
{
    public int Id { get; set; }
    public IEnumerable<CinemaHall> CinemaHalls { get; set; }
}
```

```
public class CinemaHall
{
    public int Id { get; set; }
    public int CinemaId { get; set; } // foreign key
    public Cinema Cinema { get; set; } // not mandatory but useful in case Include is needed
}
```

## `many-to-many relationships`:

### With intermediate entity (without skipping):

```
public class Book
{
    public int BookId { get; set; }
    public ICollection<BookCategory> BookCategories { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
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

### Without intermediate entity (with skipping):

```
public class Movie
{
    public int Id { get; set; }
    public HashSet<Genre> Genres { get; set; }
}
```

```
public class Genre
{
    public int Id { get; set; }
    public HashSet<Movie> Movies { get; set; }
}
```

```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Movie>()
        .HasMany(x => x.Genres).WithMany(x => x.Movies);
}
```

###

`Inverse property`

Example: two foreign keys for the same principal table.

```
public class Person
{
    public int Id { get; set; }
    [InverseProperty("Sender")]
    public IEnumerable<Message> SentMessages { get; set; }
    [InverseProperty("Receiver")]
    public IEnumerable<Message> ReceivedMessages { get; set; }
}
```

```
public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int SenderId { get; set; }
    public Person Sender { get; set; }
    public int ReceiverId { get; set; }
    public Person Receiver { get; set; }
}
```

## `OnDelete`

`Cascade` - the dependent entities are deleted if the principal entity is deleted

`No action` - what is says

`Restrict` - delete is not executed on dependent entities

# DTO

Data transfer objects, does not have a table in the database but is used to transfer data to and from the server.

# Migrations

```
update-database -migration 0 // unapply all migrations

remove-migration -force // revert to database level, or add a new migration if it should be partially reverted

drop-database // delete database
```

# DbContext

```
context.Add(entity);
context.Entry(entity).State = EntityState.Added; // same thing

context.Update(entity); // update all columns
context.Entry(entity).Property(x => x.Name).IsModified = true; // only update certain columns
```

Arbitrary quieries (can be combined with LINQ):

```
var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

var genre = await context.Genres
        .FromSqlInterpolated(
            $"SELECT * FROM Genres WHERE Id = {id}")
        .IgnoreQueryFilters()
        .FirstOfDefaultAsync(); // same
```

# Optimization

## `FirstOrDefault()` vs `Find()`:

- `FirstOrDefault` - always executes a query to the database
- `Find` - only queries the database in case the requested entity is not loaded in the database context. **Can only be used when the primary key is passed as a parameter.**
