using Microsoft.EntityFrameworkCore;
using SS15Laundry.Data;
using SS15Laundry.Models;

namespace SS15Laundry.Repository;

public class PickService:IPickUpService,IDisposable
{
    private readonly AppDbContext _context;
	public PickService(AppDbContext context)
	{
        _context = context;
	}

    public async Task<bool> Delete(Guid Id)
    {
        try
        {
            var pickup = await _context.PickUp.FindAsync(Id);
            if (pickup is null) return false;
            _context.PickUp.Remove(pickup);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public async Task<List<PickUp>> GetPickupList()
        => await _context.PickUp.ToListAsync();

    public async Task<PickUp?> GetPickupList(Guid Id)
        => await _context.PickUp.FindAsync(Id);

    public async Task<bool> Save(PickUp pickup)
    {
        try
        {
            pickup.PickUpId = Guid.NewGuid();
            _context.PickUp.Add(pickup);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Update(Guid Id, PickUp pickup)
    {
        try
        {
            var p = await _context.PickUp.FindAsync(Id);
            if (p is null) return false;
            p.CustomerId = pickup.CustomerId;
            p.Discount = pickup.Discount;
            p.EmployeeId = pickup.EmployeeId;
            p.GrandTotal = pickup.GrandTotal;
            p.IssueDate = pickup.IssueDate;
            p.Noted = pickup.Noted;
            p.Total = pickup.Total;
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}

