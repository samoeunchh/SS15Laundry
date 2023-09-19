using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS15Laundry.Models;

public class Employee
{
	[Key]
	public Guid EmployeeId { get; set; }
	[ForeignKey("Position")]
	public Guid PositionId { get; set; }
	[Required]
	[MaxLength(50)]
	[Display(Name ="Employee Name")]
	public string? EmployeeName { get; set; }
	[MaxLength(20)]
	[Phone]
	public string? Phone { get; set; }
	[MaxLength(50)]
	[EmailAddress]
	public string? Email { get; set; }
	[MaxLength(500)]
	[DataType(DataType.MultilineText)]
	public string? Address { get; set; }
	public Position? Postion { get; set; }
}

