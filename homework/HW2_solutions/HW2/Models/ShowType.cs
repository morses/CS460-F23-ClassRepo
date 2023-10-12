using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models;

[Table("ShowType")]
public partial class ShowType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string ShowTypeIdentifier { get; set; }

    [InverseProperty("ShowType")]
    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
