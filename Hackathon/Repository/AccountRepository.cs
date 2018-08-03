using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Models;

namespace Hackathon.Repository
{
    public class AccountRepository
    {
        DbAccountContext DB = new DbAccountContext();

        public void CreateAccount(Account op)
        {
            op.IsMain = true;
            var Result = DB.Accounts.Add(op);
            DB.SaveChanges();
        }
        public void AddDependent(Account op)
        {
            op.IsMain = false;
            var Result = DB.Accounts.Add(op);
            DB.SaveChanges();
        }

        public Account GetAccount(int accountId) => DB.Accounts.SingleOrDefault(x => x.ID== accountId);

        public IEnumerable<Account> GetSubAccounts(int accountID)
        {
            return DB.Accounts
                .Where(x => x.MainAccountID == accountID && x.IsMain == false)
                .ToList();
        }

        public IEnumerable<TranAccount> GetTrans(int accountID) => DB.Transactions
            .Where(x => x.AccountID == accountID)
            .ToList();

        public void Transfer(int accountId, int subAccountId, float ammount)
        {
            var mainAccount = DB.Accounts.SingleOrDefault(b => b.ID == accountId);
            var subAccount = DB.Accounts.SingleOrDefault(b => b.ID == subAccountId);

            mainAccount.balance -= ammount;
            subAccount.balance += ammount;


            TranAccount tran = new TranAccount();
            tran.AccountID = accountId;
            tran.tanAmmount = ammount;
            tran.TransactionDate = DateTime.Now;
            tran.Type = "Transfer";
            DB.Transactions.Add(tran);

            DB.SaveChanges();

        }
        public string Deposit(int accountID, float amount )
        {
            var Result = DB.Accounts.SingleOrDefault(b => b.ID == accountID);
            Result.balance += amount;

            TranAccount tran = new TranAccount();
            tran.AccountID = accountID;
            tran.tanAmmount = amount;
            tran.TransactionDate = DateTime.Now;
            tran.Type = "Depost";
            DB.Transactions.Add(tran);


            DB.SaveChanges();
            return "seccessfuly Deposit";
        }
        public void Refund(int ID )
        {
            TranAccount tran = new TranAccount();

            var Result = DB.Accounts.SingleOrDefault(b => b.ID == ID);
            Result.balance -= Result.balance;
            tran.AccountID = ID;
            tran.tanAmmount = Result.balance;
            tran.Type = "Refund";
            tran.TransactionDate = DateTime.Now;
            DB.Transactions.Add(tran);

            DB.SaveChanges();
        }

    }
}