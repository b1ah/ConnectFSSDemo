using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConnectFSS_Demo.Models
{
    public class UserMetaData
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "This field is required.")]
        public string username;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string password;

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string first_name;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string last_name;
    }
} 