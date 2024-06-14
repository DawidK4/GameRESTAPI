using Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<BackpackSlots> BackpackSlots { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharactersTitles> CharactersTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }

    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title
            {
                PK = 1,
                nam = "name1"
            },
            new Title
            {
                PK = 2,
                nam = "name2"
            }
        });

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                PK = 1,
                name = "item1",
                weig = 10
            },
            new Item
            {
                PK = 2,
                name = "item2",
                weig = 12
            },
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
            {
                PK = 1,
                FirstName = "John",
                LastName = "Doe",
                CurrentWeig = 10,
                MaxWeight = 13,
                Money = 1000
            },
            new Character
            {
                PK = 2,
                FirstName = "Matt",
                LastName = "Smith",
                CurrentWeig = 18,
                MaxWeight = 16,
                Money = 1234
            },
            new Character
            {
                PK = 3,
                FirstName = "Will",
                LastName = "Smith",
                CurrentWeig = 0,
                MaxWeight = 1000000,
                Money = 1000
            }
        });

        modelBuilder.Entity<CharactersTitles>().HasData(new List<CharactersTitles>
        {
            new CharactersTitles
            {
                FKTitle = 1,
                FKCharact = 1
            },
            new CharactersTitles
            {
                FKTitle = 1,
                FKCharact = 2
            },
            new CharactersTitles
            {
                FKTitle = 2,
                FKCharact = 1
            }
        });

        modelBuilder.Entity<BackpackSlots>().HasData(new List<BackpackSlots>
        {
            new BackpackSlots
            {
                PK = 1,
                FK_item = 1,
                FK_character = 1
            },
            new BackpackSlots
            {
                PK = 2,
                FK_item = 1,
                FK_character = 2
            },
            new BackpackSlots
            {
                PK = 3,
                FK_item = 2,
                FK_character = 2 
            }
        });
    }
}