﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models;

[Table("Role")]
public partial class Role
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(32)]
    public string RoleName { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();
}
