using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Domain.Repository;
using PhoneBook.Infrastructre.Persistent.Dapper;
using PhoneBook.Infrastructre.Persistent.EF;
using PhoneBook.Infrastructre.Persistent.EF.PhoneBooks;
using PhoneBook.Infrastructre.Persistent.EF.Users;
namespace PhoneBook.Infrastructre;

public static class InfrastructureBootstrapper
{
    public static void Init(this IServiceCollection services, string connectionString)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPhoneBookRepository, PhoneBookRepository>();

        services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<PBContext>(option =>
        {   
            option.UseSqlServer(connectionString);
        });
    }
}