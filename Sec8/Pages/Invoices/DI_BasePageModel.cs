using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sec8.Data;

namespace Sec8.Pages.Invoices
{
    public class DI_BasePageModel :PageModel
    {
        protected ApplicationDbContext context { get; }
        protected IAuthorizationService authorizationService { get; }
        protected UserManager<IdentityUser> userManager { get; }

        public DI_BasePageModel(
            ApplicationDbContext context ,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
            
        }
    }
}
