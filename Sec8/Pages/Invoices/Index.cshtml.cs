using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sec8.Data;
using Sec8.Models;

namespace Sec8.Pages.Invoices
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly Sec8.Data.ApplicationDbContext _context;

        public IndexModel(Sec8.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Invoice != null)
            {
                Invoice = await _context.Invoice.ToListAsync();
            }
        }
    }
}
