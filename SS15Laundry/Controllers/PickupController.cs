using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS15Laundry.Data;
using SS15Laundry.Repository;

namespace SS15Laundry.Controllers
{
    public class PickupController : Controller
    {
        private readonly IPickUpService _service;
        private readonly AppDbContext _context;
        public PickupController(IPickUpService service,
            AppDbContext context)
        {
            _service = service;
            _context = context;
        }
        // GET: Pickup
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetPickupList());
        }

        // GET: Pickup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pickup/Create
        public ActionResult Create()
        {
            ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["Employee"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName");
            ViewData["Item"] = new SelectList(_context.Item, "ItemId", "ItemName");
            return View();
        }

        public async Task<JsonResult> GetItem(Guid Id)
            => Json(await _context.Item.Where(x => x.ItemId.Equals(Id)).FirstOrDefaultAsync());
        // POST: Pickup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pickup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pickup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pickup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pickup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}