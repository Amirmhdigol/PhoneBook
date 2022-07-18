using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneBook.Application.Users.Login;
using PhoneBook.Application.Utils;
using PhoneBook.P.Facade.Users;
using PhoneBook.RazorPage.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.RazorPage.Pages;

[BindProperties]
[ValidateAntiForgeryToken]
public class LoginModel : PageModel
{
    private readonly IUserFacade _userFacade;
    public LoginModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [DisplayName("نام کاربری"), Required(ErrorMessage = "{0} را وارد کنید")]
    public string UserName { get; set; }

    [DisplayName("رمز"), Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity.IsAuthenticated) return Redirect("/");
        else return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var token = await _userFacade.Login(new LoginUserCommand(UserName, Password));

        HttpContext.Response.Cookies.Append("token", token, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddDays(7),
        });

        return Redirect("/");
    }
}