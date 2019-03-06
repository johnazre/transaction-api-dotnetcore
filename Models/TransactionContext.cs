using Microsoft.EntityFrameworkCore;

namespace TransactionAPI.Models
{
    public class TransactionContext : DbContext
    {
        public TransactionContext
            (DbContextOptions<TransactionContext> options) : base(options)         
        {         
        }       
        public DbSet<Transaction> Transactions { get; set; }     
  
    } 
}