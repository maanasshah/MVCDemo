using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Payee { get; set; }
        public string Memo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
    }
}