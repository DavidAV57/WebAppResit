using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Data;
using WebAppResit.Models;
using Microsoft.AspNetCore.Identity;
namespace WebAppResit.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly WebAppResitContext _context;
        public IndexModel(WebAppResitContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<BookItem> BookItem { get;set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.BookItems != null)
            {
                BookItem = await _context.BookItems.ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostBuyAsync(string itemISBN)
        {
            var user = await _userManager.GetUserAsync(User);
            CheckoutCustomer customer = await _context
                .CheckoutCustomers
                .FindAsync(user.Email);
            var item = await _context.BasketItems.FirstOrDefaultAsync(b => b.StockID == itemISBN && b.BasketID == customer.BasketID);
            if (item == null)
            {

                BasketItem newItem = new BasketItem
                {
                    BasketID = customer.BasketID,   
                    StockID = itemISBN,
                    Quantity = 1
                };
                _context.BasketItems.Add(newItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                item.Quantity += 1;
                _context.Attach(item).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw new Exception("Basket item not found!", e);
                }
            }

            return RedirectToPage();
        }
    }
}
