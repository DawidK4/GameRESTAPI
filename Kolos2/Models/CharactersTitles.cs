using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Models;

[Table("Character_Titles")]
[PrimaryKey("FKCharact", "FKTitle")]
public class CharactersTitles
{
    [ForeignKey("Character")]
    [Column("FK_charact")]
    public int FKCharact { get; set; }
    public Character Character { get; set; }
    [ForeignKey("Title")]
    [Column("FK_title")]
    public int FKTitle { get; set; }
    public Title Title { get; set; }
    [Column("aquire_at")]
    public DateTime AquireAt { get; set; }
    
}