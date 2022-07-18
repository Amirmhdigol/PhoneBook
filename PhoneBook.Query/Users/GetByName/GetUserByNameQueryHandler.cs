using Dapper;
using MediatR;
using PhoneBook.Infrastructre.Persistent.Dapper;
using PhoneBook.Query.Users.DTOs;

namespace PhoneBook.Query.Users.GetByName;

public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserDTO>
{
    private readonly DapperContext _dapperContext;
    public GetUserByNameQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<UserDTO> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        var sql = $"select top 1 * from {_dapperContext.Users} where Name=@name";
        using var context = _dapperContext.CreateConnection();
        var res = await context.QueryFirstOrDefaultAsync<UserDTO>(sql, new { name = request.Name });
        return res;
    }
}