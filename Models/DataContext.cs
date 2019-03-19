using Microsoft.EntityFrameworkCore;

namespace TransactionAPI.Models
{
  public class DataContext : DbContext
  {
    public DataContext
        (DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
  }
}