using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneBook.Application.Users.Register;
using PhoneBook.P.Facade.Users;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.RazorPage.Pages;
[BindProperties]
[ValidateAntiForgeryToken]
public class RegisterModel : PageModel
{
    private readonly IUserFacade _userFacade;
    public RegisterModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [DisplayName("نام"), Required(ErrorMessage = "{0} را وارد کنید")]
    public string Name { get; set; }

    [DisplayName("شماره تلفن"), Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [DisplayName("رمز"), Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
    [DataType(DataType.Password)]
    public string Email { get; set; }

    [DisplayName("تکرار رمز"), Required(ErrorMessage = "{0} را وارد کنید"), Compare("Password", ErrorMessage = "کلمه های عبور یکسان نیستند")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DisplayName("تکرار رمز"), Required(ErrorMessage = "{0} را وارد کنید"), Compare("Password", ErrorMessage = "کلمه های عبور یکسان نیستند")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var res = await _userFacade.RegisterUser(new RegisterUserCommand(Name, Password, Email));
        if (res) return RedirectToPage("Login"); else return Page();
    }
}