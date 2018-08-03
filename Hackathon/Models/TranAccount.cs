using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class TranAccount
    {
        [Key]
        public int ID { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        public float tanAmmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }


    }

}