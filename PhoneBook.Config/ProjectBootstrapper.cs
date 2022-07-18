using Microsoft.Extensions.DependencyInjection;
using PhoneBook.P.Facade;
using PhoneBook.Infrastructre;
using MediatR;
using PhoneBook.Query.Users.GetList;
using PhoneBook.Application.Users.Register;

namespace PhoneBook.Config;
public static class ProjectBootstrapper
{
    public static void RegisterDependency(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services,connectionString);
        FacadeBootstraper.InitFacadeDependency(services);

        services.AddMediatR(typeof(GetUserListQuery).Assembly);
        services.AddMediatR(typeof(RegisterUserCommand).Assembly);
    }
}