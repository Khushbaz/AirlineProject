using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirlineProject.Data;
using AirlineProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace AirlineProject.Controllers
{
    [Authorize]
    public class TravellersController : Controller
    {
        private readonly AirlineProjectContext _context;

        public TravellersController(AirlineProjectContext context)
        {
            _context = context;
        }

        // GET: Travellers
        public async Task<IActionResult> Index()
        {
            var airlineProjectContext = _context.Traveller.Include(t => t.StaffMember_ID);
            return View(await airlineProjectContext.ToListAsync());
        }

        // GET: Travellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveller = await _context.Traveller
                .Include(t => t.StaffMember_ID)
                .FirstOrDefaultAsync(m => m.TravellerID == id);
            if (traveller == null)
            {
                return NotFound();
            }

            return View(traveller);
        }
        [Authorize]
        // GET: Travellers/Create
        public IActionResult Create()
        {
            ViewData["StaffMemberID"] = new SelectList(_context.StaffMember, "StaffMemberName", "StaffMemberName");
            return View();
        }

        // POST: Travellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravellerID,TravellerName,ContactNumber,StaffMemberName")] Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traveller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffMemberID"] = new SelectList(_context.StaffMember, "StaffMemberName", "StaffMemberName", traveller.StaffMemberID);
            return View(traveller);
        }
        [Authorize]
        // GET: Travellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveller = await _context.Traveller.FindAsync(id);
            if (traveller == null)
            {
                return NotFound();
            }
            ViewData["StaffMemberID"] = new SelectList(_context.StaffMember, "StaffMemberName", "StaffMemberName", traveller.StaffMemberID);
            return View(traveller);
        }

        // POST: Travellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravellerID,TravellerName,ContactNumber,StaffMemberName")] Traveller traveller)
        {
            if (id != traveller.TravellerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traveller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravellerExists(traveller.TravellerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffMemberID"] = new SelectList(_context.StaffMember, "StaffMemberName", "StaffMemberName", traveller.StaffMemberID);
            return View(traveller);
        }

        // GET: Travellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveller = await _context.Traveller
                .Include(t => t.StaffMember_ID)
                .FirstOrDefaultAsync(m => m.TravellerID == id);
            if (traveller == null)
            {
                return NotFound();
            }

            return View(traveller);
        }

        // POST: Travellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traveller = await _context.Traveller.FindAsync(id);
            _context.Traveller.Remove(traveller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravellerExists(int id)
        {
            return _context.Traveller.Any(e => e.TravellerID == id);
        }
    }
}
