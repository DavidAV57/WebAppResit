using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Data;
using WebAppResit.Models;

namespace WebAppResit.Pages.Menu
{
    public class EditModel : PageModel
    {
        private readonly WebAppResit.Data.WebAppResitContext _context;

        public EditModel(WebAppResit.Data.WebAppResitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookItem BookItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.BookItems == null)
            {
                return NotFound();
            }

            var bookitem =  await _context.BookItems.FirstOrDefaultAsync(m => m.ISBN == id);
            if (bookitem == null)
            {
                return NotFound();
            }
            BookItem = bookitem;
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookItemExists(BookItem.ISBN))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookItemExists(string id)
        {
          return _context.BookItems.Any(e => e.ISBN == id);
        }
    }
}
