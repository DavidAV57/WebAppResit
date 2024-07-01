using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Data;
using WebAppResit.Models;

namespace WebAppResit.Menu
{
    public class DeleteModel : PageModel
    {
        private readonly WebAppResit.Data.WebAppResitContext _context;

        public DeleteModel(WebAppResit.Data.WebAppResitContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookItem BookItem { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.BookItem == null)
            {
                return NotFound();
            }

            var bookitem = await _context.BookItem.FirstOrDefaultAsync(m => m.ISBN == id);

            if (bookitem == null)
            {
                return NotFound();
            }
            else 
            {
                BookItem = bookitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.BookItem == null)
            {
                return NotFound();
            }
            var bookitem = await _context.BookItem.FindAsync(id);

            if (bookitem != null)
            {
                BookItem = bookitem;
                _context.BookItem.Remove(BookItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
