using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Sec8.Models;

namespace Sec8.Authorization
{
    public class InvoiceCreatorAuthorizatioHandler : AuthorizationHandler<OperationAuthorizationRequirement, Invoice>
    {
        UserManager<IdentityUser> _userManager;

        public InvoiceCreatorAuthorizatioHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Invoice invoice)
        {
            if (context.User == null || invoice == null)
                return Task.CompletedTask;

            if (requirement.Name != Constants.CreateOperationName &&
                  requirement.Name != Constants.DeleteOperationName &&
                  requirement.Name != Constants.UpdateOperationName &&
                  requirement.Name != Constants.ReadOperationName
               )
            {
                return Task.CompletedTask;
            }

            if (invoice.CreatorId == _userManager.GetUserId(context.User))
                context.Succeed(requirement);
            
                return Task.CompletedTask;
            
        }
    }
}
