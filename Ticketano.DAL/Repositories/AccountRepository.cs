using Microsoft.EntityFrameworkCore;
using Ticketano.DAL.Models;

namespace Ticketano.DAL.Repositories;

public class AccountRepository: BaseRepository<User>
{
    public AccountRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await this.Db.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
    }
}