using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JqueryAjax.CoreCrud.Models;
using JqueryAjax.CoreCrud.Helpers;

namespace JqueryAjax.CoreCrud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindContext _context;

        public CategoryController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }



        // GET: Category/AddOrEdit
        // GET: Category/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id==0)
            {
                return View(new Category());

            }
            else
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }
  

        // POST: Category/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("CategoryId,CategoryName,Description")] Category category)
        {
            
            if (ModelState.IsValid)
            {
                if (id==0)
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.CategoryId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Categories.ToList()) });
            }
            // if we cant add or uptade, we return the same html code
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this,"AddOrEdit",category) }); 
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Categories.ToList()) });
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
