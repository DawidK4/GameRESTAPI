using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos2.Models;

[Table("Items")]
public class Item
{
    [Key]
    [Column("PK")]
    public int PK { get; set; }
    [Column("name", TypeName = "varchar(50)")]
    public string name { get; set; }
    [Column("weig")]
    public int weig { get; set; }

    public IEnumerable<BackpackSlots> BackpackSlots;
}