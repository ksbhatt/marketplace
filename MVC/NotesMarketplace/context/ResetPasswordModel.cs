using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NotesMarketplace.context
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "New password required", AllowEmptyStrings = false)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare(" NewPassword ", ErrorMessage = "New password and confirm password don not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ResetCode { get; set; }
    }
}