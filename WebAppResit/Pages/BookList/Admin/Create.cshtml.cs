using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppResit.Data;
using WebAppResit.Models;

namespace WebAppResit.Pages.Menu
{
    public class CreateModel : PageModel
    {
        private readonly WebAppResit.Data.WebAppResitContext _context;

        public CreateModel(WebAppResit.Data.WebAppResitContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookItem BookItem { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                BookItem.ImageData = ms.ToArray();
                
                ms.Close();
                ms.Dispose();
            }
            _context.BookItems.Add(BookItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
