using MediatR;
using Dapper;
using PhoneBook.Query.Users.DTOs;
using PhoneBook.Infrastructre.Persistent.Dapper;

namespace PhoneBook.Query.Users.GetTokenByJWTToken;

public class GetTokenByJWTTokenQueryHandler : IRequestHandler<GetTokenByJWTTokenQuery, UserTokenDTO>
{
    private readonly DapperContext _dapperContext;
    public GetTokenByJWTTokenQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public Task<UserTokenDTO> Handle(GetTokenByJWTTokenQuery request, CancellationToken cancellationToken)
    {
        var sql = $"select top(1) from {_dapperContext.Users} where HashedJwtToken=@HashedJwtToken";
        using var context = _dapperContext.CreateConnection();
        var res = context.QueryFirstOrDefaultAsync<UserTokenDTO>(sql, new { HashedJwtToken = request.JwtToken });
        return res;
    }
}