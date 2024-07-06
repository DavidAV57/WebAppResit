using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Data;
using WebAppResit.Models;

namespace WebAppResit.Pages;

public class CheckoutModel : PageModel
{
    private readonly WebAppResitContext _db;
    private readonly UserManager<IdentityUser> _UserManager;
    private readonly ILogger<CheckoutModel> _logger;
    public IList <CheckoutItem> Items { get; private set; }
    public decimal Total;
    public long AmountPayable;  

    public CheckoutModel(WebAppResitContext db, UserManager<IdentityUser> UserManager, ILogger<CheckoutModel> logger)
    {
        _db = db;
        _UserManager = UserManager;
        _logger = logger;
    }


    public async Task OnGetAsync()

    {
        var user = await _UserManager.GetUserAsync(User);
        CheckoutCustomer customer = await _db.CheckoutCustomers.FindAsync(user.Email);
        
        Items = _db.CheckoutItems.FromSqlRaw("SELECT BookItem.ISBN,BookItem.Price, BookItem.ItemName, BasketItems.BasketID ,BasketItems.Quantity FROM BookItem INNER JOIN BasketItems on BookItem.ISBN = BasketItems.StockID WHERE BasketID = {0}", customer.BasketID).ToList();
        if (Items == null)
        {
            Items = new List<CheckoutItem>();
        }
            Total = 0;
            foreach (var item in Items)
            {
                Total += (item.Quantity * item.Price);
            }

            AmountPayable = (long)Total;
    }
}