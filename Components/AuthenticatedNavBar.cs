using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System;

namespace BabyTracker.Components
{
    public class AuthenticatedNavBar: ViewComponent
    {
        private UserManager<IdentityUser> userManager;
        public AuthenticatedNavBar (UserManager<IdentityUser> usrMgr)
        {
            userManager = usrMgr;
        }
        public IViewComponentResult Invoke()
        {
            NavBarUserModel userModel = new NavBarUserModel
            {
                Name = userManager.GetUserName((System.Security.Claims.ClaimsPrincipal) User),
                Id = userManager.GetUserId((System.Security.Claims.ClaimsPrincipal) User)
            };          
            return View(userModel);
        }
    }

    public class NavBarUserModel
    {
        public NavBarUserModel(){}
        public string Name {get; set;}
        public string Id {get; set;}
    }
}