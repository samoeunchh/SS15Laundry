using System;
using Microsoft.EntityFrameworkCore;
using SS15Laundry.Models;

namespace SS15Laundry.Data;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{
	}
	public DbSet<Position> Position { get; set; }
	public DbSet<Employee> Employee { get; set; }
	public DbSet<Customer> Customer { get; set; }
	public DbSet<Category> Category { get; set; }
	public DbSet<Item> Item { get; set; }
	public DbSet<PickUp> PickUp { get; set; }
	public DbSet<PickUpDetail> PickUpDetail { get; set; }
}

