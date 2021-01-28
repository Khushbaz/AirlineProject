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
    public class TicketPricesController : Controller
    {
        private readonly AirlineProjectContext _context;

        public TicketPricesController(AirlineProjectContext context)
        {
            _context = context;
        }

        // GET: TicketPrices
        public async Task<IActionResult> Index()
        {
            var airlineProjectContext = _context.TicketPrice.Include(t => t.Airline_ID);
            return View(await airlineProjectContext.ToListAsync());
        }

        // GET: TicketPrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPrice = await _context.TicketPrice
                .Include(t => t.Airline_ID)
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (ticketPrice == null)
            {
                return NotFound();
            }

            return View(ticketPrice);
        }
        [Authorize]
        // GET: TicketPrices/Create
        public IActionResult Create()
        {
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName");
            return View();
        }

        // POST: TicketPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketID,TicketName,Price,AirlineName")] TicketPrice ticketPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName", ticketPrice.AirlineID);
            return View(ticketPrice);
        }
        [Authorize]
        // GET: TicketPrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPrice = await _context.TicketPrice.FindAsync(id);
            if (ticketPrice == null)
            {
                return NotFound();
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName", ticketPrice.AirlineID);
            return View(ticketPrice);
        }

        // POST: TicketPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketID,TicketName,Price,AirlineName")] TicketPrice ticketPrice)
        {
            if (id != ticketPrice.TicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketPriceExists(ticketPrice.TicketID))
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
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName", ticketPrice.AirlineID);
            return View(ticketPrice);
        }

        // GET: TicketPrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPrice = await _context.TicketPrice
                .Include(t => t.Airline_ID)
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (ticketPrice == null)
            {
                return NotFound();
            }

            return View(ticketPrice);
        }

        // POST: TicketPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketPrice = await _context.TicketPrice.FindAsync(id);
            _context.TicketPrice.Remove(ticketPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketPriceExists(int id)
        {
            return _context.TicketPrice.Any(e => e.TicketID == id);
        }
    }
}
