using Microsoft.Extensions.DependencyInjection;
using PhoneBook.P.Facade.PhoneBooks;
using PhoneBook.P.Facade.Users;

namespace PhoneBook.P.Facade;
public static class FacadeBootstraper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IPhoneBookFacade, PhoneBookFacade>();
    }
}