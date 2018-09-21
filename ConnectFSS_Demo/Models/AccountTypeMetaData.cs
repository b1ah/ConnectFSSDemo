using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConnectFSS_Demo.Models
{
    public class AccountTypeMetaData
    {
        [Display(Name = "Type")]
        [Required(ErrorMessage = "This field is required.")]
        public string name;
    }
}