using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public int? MainAccountID { get; set; }
        [ForeignKey("MainAccountID")]
        public Account MainAccount { get; set; }

        [RegularExpression(@"^[\u0000-\u007F]+$",ErrorMessage ="Only English")]
        public string Name { get; set; }

        [RegularExpression(@"^([1|2|7][0-9]{9})$",ErrorMessage ="Enter correct number")]
        public int IqamaID { get; set; }

        public int PhoneNumber { get; set; }
        public int numberOfDep { get; set; }
        public float balance { get; set; }
        public bool IsMain { get; set; }


        public IEnumerable<Account> SubAccounts { get; set; }


    }

}