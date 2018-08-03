using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class DepositViewModel
    {
        [Required]
        public float Amount { get; set; }
        public int AccountID { get; set; }
    }
}