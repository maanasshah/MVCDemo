using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Model;

namespace MVCDemo.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransactionById(int id);
        void UpdateTransaction(Transaction tran);

    }
}