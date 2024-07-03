using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Data;
using WebAppResit.Models;

namespace WebAppResit.Pages.Menu
{
    public class IndexModel : PageModel
    {
        private readonly WebAppResit.Data.WebAppResitContext _context;

        public IndexModel(WebAppResit.Data.WebAppResitContext context)
        {
            _context = context;
        }

        public IList<BookItem> BookItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookItems != null)
            {
                BookItem = await _context.BookItems.ToListAsync();
            }
        }
    }
}
