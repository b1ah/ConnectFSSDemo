using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConnectFSS_Demo.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    [MetadataType(typeof(AccountMetaData))]
    public partial class Account
    {
    }

    [MetadataType(typeof(AccountTypeMetaData))]
    public partial class AccountType
    {
    }
}