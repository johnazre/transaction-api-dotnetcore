using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionAPI.Models;

namespace TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private TransactionContext _context;
        
        public TransactionsController(TransactionContext context)
        {
            _context = context;
        }
        
        // GET api/transactions
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            return _context.Transactions;
        }

        // GET api/transactions/5
        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(int id)
        {
            return _context.Transactions
                // Find the first one that meets this condition 
                .FirstOrDefault(trans => trans.Id == id);
        }

        // POST api/transactions
        [HttpPost]
        public void Post([FromBody] Transaction newTransaction)
        {
            // Set Dates
            newTransaction.CreatedAt = DateTime.Now;
            newTransaction.UpdatedAt = DateTime.Now;
            
            // Execute insert
            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();
        }

        // PUT api/transactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Transaction updatedTransaction)
        {
            var entity = _context.Transactions.FirstOrDefault(trans => trans.Id == id);

            if (entity != null)
            {
                // Update each field
                entity.Amount = updatedTransaction.Amount;
                entity.BusinessName = updatedTransaction.BusinessName;
                entity.Type = updatedTransaction.Type;
                entity.UpdatedAt = DateTime.Now;
                entity.UserId = updatedTransaction.UserId;                
                
                // Execute and save the changes in the database
                _context.Transactions.Update(entity);
                _context.SaveChanges();
            }
            
            
        }

        // DELETE api/transactions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = _context.Transactions.FirstOrDefault(trans => trans.Id == id);

            if (entity != null)
            {
                _context.Transactions.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}