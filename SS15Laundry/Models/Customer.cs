using System.ComponentModel.DataAnnotations;

namespace SS15Laundry.Models;

public class Customer
{
	[Key]
	public Guid CustomerId { get; set; }
	[Required]
	[MaxLength(50)]
	public string? CustomerName { get; set; }
	[Required]
	[MaxLength(20)]
	[Phone]
	public string? Phone { get; set; }
	[MaxLength(500)]
	[DataType(DataType.MultilineText)]
	public string? Address { get; set; }
	public double Balance { get; set; }
}

