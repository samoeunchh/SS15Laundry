using System;
using System.ComponentModel.DataAnnotations;

namespace SS15Laundry.Models;

public class Position
{
    [Key]
    public Guid PositionId { get; set; }
    [Required]
    [MaxLength(50)]
    [Display(Name ="Position Name")]
    public string? PositionName { get; set; }
}


