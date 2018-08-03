using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class TransferViewModel
    {
        public int AccountID { get; set; }
        public int SubAccountID { get; set; }
        public IEnumerable<Account> SubAccounts { get; set; }
        public float Amount { get; set; }
    }
}