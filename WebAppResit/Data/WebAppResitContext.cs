using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppResit.Models;

namespace WebAppResit.Data
{
    public class WebAppResitContext : DbContext
    {
        public WebAppResitContext (DbContextOptions<WebAppResitContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppResit.Models.BookItem> BookItem { get; set; } = default!;
    }
}
