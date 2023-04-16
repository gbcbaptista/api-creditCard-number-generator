using Microsoft.EntityFrameworkCore;
using testCore.Models;

namespace testCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        public DbSet<Digital_credit_card> Cards {get; set;}
        public DbSet<Users> User {get; set;}
    }
}