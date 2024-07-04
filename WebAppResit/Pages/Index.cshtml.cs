using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Data;
using WebAppResit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebAppResit.Pages
{
    [Authorize (Roles ="Admin   ,Member")]
    public class IndexModel : PageModel
    {
        /*private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/
        private readonly WebAppResitContext _context;
        
        public IndexModel(WebAppResitContext context)
        {
            _context = context;
        }

        public IList<BookItem> BookItems { get; set; } = default;

        //private readonly WebAppResitContext _db;
        [BindProperty]
        public string Search { get; set; }
        public void OnGet()
        {
            BookItems = _context.BookItems.FromSqlRaw("Select * FROM BookItem").ToList();
        }
        
        public IActionResult OnPostSearch()
        {
            BookItems = _context.BookItems
                .FromSqlRaw("Select * FROM BookItem WHERE ItemName Like '" + Search + "%'").ToList();
         return Page();
        }
    }
}
