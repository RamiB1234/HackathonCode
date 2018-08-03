using Hackathon.Models;
using System.Linq;
using System.Web.Mvc;
using Hackathon.Repository;
using System.Data.Entity;

namespace Hackathon.Controllers
{
    public class HomeController: Controller
    {
        AccountRepository accRepo = new AccountRepository();
        DbAccountContext DB = new DbAccountContext();
        public ActionResult Index()
        {

          var list=DB.Accounts
                .Where(x =>x.IsMain==true)

                .ToList();
        
            foreach(var acc in list)
            {
                acc.SubAccounts = accRepo.GetSubAccounts(acc.ID);
            }
           
            return View(list);
        }

        public ActionResult CreateAccount()
        {
            return View(new Account());
        }


        [HttpPost]
        public ActionResult CreateAccount(Account model)
        {
            if(ModelState.IsValid)
            {
                accRepo.CreateAccount(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult AddSubAccount(int accountId)
        {
            var model = new Account()
            {
                MainAccountID = accountId
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult AddSubAccount(Account account)
        {
            if (ModelState.IsValid)
            {
                accRepo.AddDependent(account);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Deposit(int accountId)
        {
            var model = new DepositViewModel()
            {
                AccountID = accountId
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Deposit(DepositViewModel model)
        {
            if (ModelState.IsValid)
            {
                accRepo.Deposit(model.AccountID, model.Amount);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Transfer(int accountId)
        {
            var model = new TransferViewModel()
            {
                SubAccounts = accRepo.GetSubAccounts(accountId),
                AccountID = accountId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Transfer(TransferViewModel model)
        {
            var mainAccount = accRepo.GetAccount(model.AccountID);

            if (mainAccount.balance < model.Amount)
            {
                ModelState.AddModelError("", $"You dont have enough balance. Your balance is:{mainAccount.balance}");
            }

            if (ModelState.IsValid)
            {
                
                accRepo.Transfer(model.AccountID, model.SubAccountID, model.Amount);
                return RedirectToAction("Index");
            }
            else
            {
                model.SubAccounts = accRepo.GetSubAccounts(model.AccountID);
                return View(model);
            }
        }

        public ActionResult Transactions(int accountId)
        {
            return View(accRepo.GetTrans(accountId));
        }


        public ActionResult SubAccounts(int accountId)
        {
            return View(accRepo.GetSubAccounts(accountId));
        }

    }
}