using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS15Laundry.Models;

public class Item
{
	[Key]
	public Guid ItemId { get; set; }
	[ForeignKey("Category")]
	public Guid CategoryId { get; set; }
	[Required]
	[MaxLength(50)]
	[Display(Name ="Item Name")]
	public string? ItemName { get; set; }
	public double Price { get; set; }

	public Category? Category { get; set; }
}

