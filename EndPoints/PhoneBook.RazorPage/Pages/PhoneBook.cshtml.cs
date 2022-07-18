using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhoneBook.RazorPage.Pages;

[Authorize]
public class PhoneBookModel : PageModel
{
    public void OnGet()
    {
    }
}
