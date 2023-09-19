using System;
using SS15Laundry.Models;

namespace SS15Laundry.Repository;

public interface IPickUpService
{
    Task<List<PickUp>> GetPickupList();
    Task<PickUp?> GetPickupList(Guid Id);
    Task<bool> Save(PickUp pickup);
    Task<bool> Delete(Guid Id);
    Task<bool> Update(Guid Id, PickUp pickup);
}

