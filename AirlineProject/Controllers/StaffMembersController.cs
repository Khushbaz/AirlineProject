﻿using System;
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
    
    public class StaffMembersController : Controller
    {
        private readonly AirlineProjectContext _context;

        public StaffMembersController(AirlineProjectContext context)
        {
            _context = context;
        }

        // GET: StaffMembers
        public async Task<IActionResult> Index()
        {
            var airlineProjectContext = _context.StaffMember.Include(s => s.Airline_ID);
            return View(await airlineProjectContext.ToListAsync());
        }

        // GET: StaffMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffMember = await _context.StaffMember
                .Include(s => s.Airline_ID)
                .FirstOrDefaultAsync(m => m.StaffMemberID == id);
            if (staffMember == null)
            {
                return NotFound();
            }

            return View(staffMember);
        }
        [Authorize]
        // GET: StaffMembers/Create
        public IActionResult Create()
        {
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName");
            return View();
        }

        // POST: StaffMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffMemberID,StaffMemberName,ContactNumber,EmailId,AirlineName")] StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName", staffMember.AirlineID);
            return View(staffMember);
        }
        [Authorize]
        // GET: StaffMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffMember = await _context.StaffMember.FindAsync(id);
            if (staffMember == null)
            {
                return NotFound();
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName", staffMember.AirlineID);
            return View(staffMember);
        }

        // POST: StaffMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffMemberID,StaffMemberName,ContactNumber,EmailId,AirlineName")] StaffMember staffMember)
        {
            if (id != staffMember.StaffMemberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffMemberExists(staffMember.StaffMemberID))
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
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineName", "AirlineName", staffMember.AirlineID);
            return View(staffMember);
        }

        // GET: StaffMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffMember = await _context.StaffMember
                .Include(s => s.Airline_ID)
                .FirstOrDefaultAsync(m => m.StaffMemberID == id);
            if (staffMember == null)
            {
                return NotFound();
            }

            return View(staffMember);
        }

        // POST: StaffMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffMember = await _context.StaffMember.FindAsync(id);
            _context.StaffMember.Remove(staffMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffMemberExists(int id)
        {
            return _context.StaffMember.Any(e => e.StaffMemberID == id);
        }
    }
}
