using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaelytDocumentInfo.Models;
using Paelyt_Data_System.Data;
using Microsoft.AspNetCore.Hosting;
using Paelyt_Data_System.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace Paelyt_Data_System.Controllers
{
    public class PersonalImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PersonalImagesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: PersonalImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalImages.ToListAsync());
        }

        // GET: PersonalImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalImage = await _context.PersonalImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalImage == null)
            {
                return NotFound();
            }

            return View(personalImage);
        }

       // GET: PersonalImages/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}
        public IActionResult Create()
        {
            PersonImages vm = new PersonImages();
            ViewBag.images = new SelectList(_context.PersonalDatas.ToList(), "Id", "Name");
            return View(vm);
        }

        // POST: PersonalImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ImageId,ImageURL")] PersonalImage personalImage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(personalImage);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(personalImage);
        //}
        //ProductImages/ Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonImages vm)
        {
            foreach(var item in vm.Images)
            {
                string stringFileName = UploadFile(item);
                var personImage = new PersonalImage
                {
                     ImageURL = stringFileName,
                    PersonalData = vm.PersonalData,
                };
                _context.PersonalImages.Add(personImage);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile file)
        {
            string fileName = null;
            if(fileName != null)
            {
                string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        // GET: PersonalImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalImage = await _context.PersonalImages.FindAsync(id);
            if (personalImage == null)
            {
                return NotFound();
            }
            return View(personalImage);
        }

        // POST: PersonalImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Id,ImageURL")] PersonalImage personalImage)
        {
            if (id != personalImage.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalImageExists(personalImage.Id))
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
            return View(personalImage);
        }

        // GET: PersonalImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalImage = await _context.PersonalImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalImage == null)
            {
                return NotFound();
            }

            return View(personalImage);
        }

        // POST: PersonalImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalImage = await _context.PersonalImages.FindAsync(id);
            _context.PersonalImages.Remove(personalImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalImageExists(int id)
        {
            return _context.PersonalImages.Any(e => e.Id == id);
        }
    }
}
