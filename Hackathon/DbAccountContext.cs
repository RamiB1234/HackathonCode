using Hackathon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hackathon
{
    public class DbAccountContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TranAccount> Transactions { get; set; }

    }
}