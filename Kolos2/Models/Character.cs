using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos2.Models;

[Table("Characters")]
public class Character
{
    [Key]
    [Column("PK")]
    public int PK { get; set; }
    [Column("first_name", TypeName = "varchar(50)")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Column("last_name", TypeName = "varchar(50)")]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Column("current_weig")]
    public int CurrentWeig { get; set; }
    [Column("max_weight")]
    public int MaxWeight { get; set; }
    [Column("money")]
    public int Money { get; set; }
    
    public IEnumerable<BackpackSlots> BackpackSlots { get; set; }
    public IEnumerable<CharactersTitles> CharactersTitles { get; set; }
}