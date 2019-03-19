using System;

namespace TransactionAPI.Models
{
  public class Transaction
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int Amount { get; set; }
    public string Type { get; set; }
    public string BusinessName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}