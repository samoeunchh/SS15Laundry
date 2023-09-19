using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS15Laundry.Models;

public class PickUpDetail
{
	[Key]
	public Guid PickUpDetailId { get; set; }
	//[ForeignKey("PickUp")]
	public Guid PickUpId { get; set; }
    [ForeignKey("PickUp")]
    public Guid ItemId { get; set; }
	public int Qty { get; set; }
	public double Price { get; set; }
	public double Amount { get; set; }

	//public PickUp? PickUp { get; set; }
    public Item? Item { get; set; }
}

