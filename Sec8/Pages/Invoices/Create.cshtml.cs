using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sec8.Authorization;
using Sec8.Data;
using Sec8.Models;

namespace Sec8.Pages.Invoices
{
    public class CreateModel : DI_BasePageModel
    {
      //  private readonly Sec8.Data.ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base(context,authorizationService,userManager)
        {
           // _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Invoice Invoice { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || context.Invoice == null || Invoice == null)
            //  {
            //      return Page();
            //  }

            Invoice.CreatorId = userManager.GetUserId(User);

            var isAuthorized = await authorizationService.AuthorizeAsync(
                User, Invoice, InvoiceOperations.Create);

            if(isAuthorized.Succeeded == false)
                return Forbid();

            context.Invoice.Add(Invoice);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
