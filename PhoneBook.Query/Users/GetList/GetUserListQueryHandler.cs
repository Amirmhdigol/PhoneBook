using Dapper;
using MediatR;
using PhoneBook.Infrastructre.Persistent.Dapper;
using PhoneBook.Query.Users.DTOs;

namespace PhoneBook.Query.Users.GetList;
public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDTO>>
{
    private readonly DapperContext _context;
    public GetUserListQueryHandler(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<UserDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var sql = $"select * from {_context.Users}";
        using var context = _context.CreateConnection();

        var result = await context.QueryAsync<UserDTO>(sql);
        return result.ToList();
    }
}