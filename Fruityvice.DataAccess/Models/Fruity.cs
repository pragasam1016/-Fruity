using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FruityVice.DataAccess;

[Table("Fruity")]
public partial class Fruity
{
    [Key]
    public int FruityId { get; set; }

    [StringLength(25)]
    public string Genus { get; set; } = null!;

    [StringLength(30)]
    public string? Name { get; set; }

    [StringLength(30)]
    public string Family { get; set; } = null!;

    [StringLength(30)]
    public string? Order { get; set; }

    [InverseProperty("Fruity")]
    public virtual ICollection<Nutrition> Nutritions { get; set; } = new List<Nutrition>();
}
