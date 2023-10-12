using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models;

[Table("ProductionCountry")]
public partial class ProductionCountry
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string CountryIdentifier { get; set; }

    [InverseProperty("ProductionCountry")]
    public virtual ICollection<ProductionCountryAssignment> ProductionCountryAssignments { get; set; } = new List<ProductionCountryAssignment>();
}
