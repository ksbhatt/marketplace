﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webapplication3.context
{
	[MetadataType(typeof(UserMetadata))]
	public partial class User
	{
		public string ConfirmPassword { get; set; }
	}
	public class UserMetadata
	{
		[Display(Name = "First Name")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
		public string LastName { get; set; }

		[Display(Name = "EmailID")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "EmailID Required")]
		[DataType(DataType.EmailAddress)]
		public string EmailID { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Minimum 6 characters required")]
		public string Password { get; set; }

		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Confirm password and Password do not match")]
		public string ConfirmPassword { get; set; }
	}
}