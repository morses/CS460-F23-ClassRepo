﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models;

[Table("AgeCertification")]
public partial class AgeCertification
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string CertificationIdentifier { get; set; }

    [InverseProperty("AgeCertification")]
    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
