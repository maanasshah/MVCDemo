using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MVCDemo.Configuration;
using MVCDemo.Model;

namespace MVCDemo.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ITransactionContext _dbContext;
        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["defaultconn"].ConnectionString);
            }
        }

        public TransactionRepository(ITransactionContext context)
        {
            this._dbContext = context;
        }

        public Transaction GetTransactionById(int id)
        {
            var result = (from val in _dbContext.Transaction
                          where val.Id == id
                          select val);
            return result.FirstOrDefault(); // expecting 1 or less records thats why choose firstordefualt. If you expect only one record use first, it will throw 
                                            // exception if it returns more than 1 row
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return (from val in _dbContext.Transaction
                        select val).OrderByDescending(o => o.PurchaseDate);
        }

        public void UpdateTransaction(Transaction tran)
        {
            string sqlQuery;
            if (tran.Id > 0)
            {
                sqlQuery = @"UPDATE [dbo].[Transaction]
                                Set Payee = @Payee, PurchaseDate = @PurchaseDate,
                                    Amount = @Amount, Memo = @Memo, CategoryId = @CategoryId
                                Where Id = @Id";
            }
            else
            {
                sqlQuery = @"INSERT INTO [dbo].[Transaction]
                                    (Payee, Amount, PurchaseDate, Memo, CategoryId)
                                VALUES
                                    (@Payee, @Amount, @PurchaseDate, @Memo, @CategoryId)";
            }
            // I can use here dbcontext.savechanges also. but just to show usage of dapper i choose this approach.
            using (var cn = Connection)
            {
                cn.Execute(sqlQuery, new
                {
                    @Payee = tran.Payee,
                    @PurchaseDate = tran.PurchaseDate,
                    @Amount = tran.Amount,
                    @Memo = tran.Memo,
                    @CategoryId = tran.CategoryId,
                    @Id = tran.Id
                });
            }
        }
    }
}