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
        //private string _confirmPassword;
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
            //get { return _confirmPassword; }
            //set { _confirmPassword = Utilties.EncryptionHandler.Encrypt(value); } }
    }
}