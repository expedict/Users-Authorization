using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace UsersApi.Models;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public DbSet<UserList> UsersItems { get; set; } = null!;
}