﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConnectFSS_Demo.Models
{
    public class AccountMetaData
    {
        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string name;

        [Display(Name = "Balance")]
        [Required(ErrorMessage = "This field is required.")]
        public decimal balance;
    }
}