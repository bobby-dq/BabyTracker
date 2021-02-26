using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace BabyTracker.Models.UserModels
{
    [Authorize(Roles="Administrator")]
    public class AdminPageModel: PageModel
    {
    }
}