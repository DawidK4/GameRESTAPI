using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos2.Models;

[Table("Titles")]
public class Title
{
    [Key]
    [Column("PK")]
    public int PK { get; set; }
    [Column("nam", TypeName = "varchar(100)")]
    [MaxLength(100)]
    public string nam { get; set; }
    
    public IEnumerable<CharactersTitles> CharactersTitles { get; set; }
}