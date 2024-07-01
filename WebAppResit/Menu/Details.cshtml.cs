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
    public class DetailsModel : PageModel
    {
        private readonly WebAppResit.Data.WebAppResitContext _context;

        public DetailsModel(WebAppResit.Data.WebAppResitContext context)
        {
            _context = context;
        }

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
    }
}
