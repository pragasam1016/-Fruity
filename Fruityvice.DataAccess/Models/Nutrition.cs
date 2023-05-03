using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FruityVice.DataAccess;

public partial class Nutrition
{
    public int Carbohydrates { get; set; }

    [Key]
    public int NutritionsId { get; set; }

    public int Protein { get; set; }

    [Column("fat")]
    public double Fat { get; set; }

    public double Calories { get; set; }

    public double Sugar { get; set; }

    public int FruityId { get; set; }

    [ForeignKey("FruityId")]
    [InverseProperty("Nutritions")]
    public virtual Fruity Fruity { get; set; } = null!;
}
