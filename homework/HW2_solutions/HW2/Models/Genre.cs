using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models;

[Table("Genre")]
public partial class Genre
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(32)]
    public string GenreString { get; set; }

    [InverseProperty("Genre")]
    public virtual ICollection<GenreAssignment> GenreAssignments { get; set; } = new List<GenreAssignment>();
}
