using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS15Laundry.Models;

public class PickUp
{
	[Key]
	public Guid PickUpId { get; set; }
	[ForeignKey("Customer")]
	public Guid CustomerId { get; set; }
    [ForeignKey("Employee")]
    public Guid EmployeeId { get; set; }
	[DataType(DataType.Date)]
	public DateTime IssueDate { get; set; }
	[MaxLength(200)]
	public string? Noted { get; set; }
	public double Total { get; set; }
	public int Discount { get; set; }
	public double GrandTotal { get; set; }
	public List<PickUpDetail> PickUpDetails { get; set; } = new List<PickUpDetail>();
	public Customer? Customer { get; set; }
	public Employee? Employee { get; set; }
}

