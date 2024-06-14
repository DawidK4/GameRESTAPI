using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos2.Models;

[Table("Backpack_Slots")]
public class BackpackSlots
{
    [Key]
    [Column("PK")]
    public int PK { get; set; }
    
    [ForeignKey("Item")]
    [Column("FK_item")]
    public int FK_item { get; set; }
    [ForeignKey("Character")]
    [Column("FK_character")]
    public int FK_character { get; set; }
    
    public Item Item { get; set; }
    public Character Character { get; set; }
}