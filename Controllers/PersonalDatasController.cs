using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaelytDocumentInfo.Models;
using Paelyt_Data_System.Data;

namespace Paelyt_Data_System.Controllers
{
    public class PersonalDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalDatas.ToListAsync());
        }

        // GET: PersonalDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalData = await _context.PersonalDatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalData == null)
            {
                return NotFound();
            }

            return View(personalData);
        }

        // GET: PersonalDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,TransactionNo")] PersonalData personalData)
        {
            try
            {
                if (ModelState.IsValid)
                {

                   await _context.AddAsync(personalData);

                     _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch(Exception e)
            {
                
            }
           

            return View(personalData);

        }

        // GET: PersonalDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalData = await _context.PersonalDatas.FindAsync(id);
            if (personalData == null)
            {
                return NotFound();
            }
            return View(personalData);
        }

        // POST: PersonalDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,TransactionNo")] PersonalData personalData)
        {
            if (id != personalData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalDataExists(personalData.Id))
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
            return View(personalData);
        }

        // GET: PersonalDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalData = await _context.PersonalDatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalData == null)
            {
                return NotFound();
            }

            return View(personalData);
        }

        // POST: PersonalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalData = await _context.PersonalDatas.FindAsync(id);
            _context.PersonalDatas.Remove(personalData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalDataExists(int id)
        {
            return _context.PersonalDatas.Any(e => e.Id == id);
        }
    }
}
