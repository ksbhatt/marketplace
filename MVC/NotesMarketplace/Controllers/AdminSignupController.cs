using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class AdminSignupController : Controller
    {
        public string ReturnUrl { get; private set; }

        private DB_Entities _db = new DB_Entities();
        // GET: AdminSignup
        [HttpGet]
        public ActionResult AdminSignup()
        {


            return View();


        }

        // GET: Signup


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminSignup([Bind(Exclude = "IsEmailVerified,IsActive")] User user)
        {

            bool Status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                #region 
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region Generate Activation Cide
                user.IsActive = true;
                #endregion

                #region 
                //    user.Password = Crypto.Hash(user.Password);
                //  user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion
                user.IsEmailVerified = false;
                user.RoleID = 2;

                #region
                Sample_1Entities1 dc = new Sample_1Entities1();


                try
                {
                    try
                    {
                        dc.Users.Add(user);
                        dc.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {

                    }

                    SendVerificationLinkEmail(user.EmailID, user.IsActive.ToString());
                    message = "Thank you for Sign up<br> Please verify the email address via clicking on the link we sent you via email.";
                    Status = true;
                }
                finally
                {
                    Dispose();
                }
                #endregion

            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            Sample_1Entities1 dc = new Sample_1Entities1();
            try
            {
                var v = dc.Users.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
            finally
            {
                Dispose();

            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string IsActive, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/User/" + emailFor + "/" + IsActive;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("kananbhatt220@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "vwmgjphqrzyuwukc";
            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {

                subject = "Your account is successfully created";


                body = "</br></br>We are excited to tell you that you account is" + "successfully created.Please cllick on the below link to verify your account" + "<br><br><a href='" + link + "'>" + link + " </a>";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br><br>We got request for reset your account password.Please click on the below link to reset your password" + "<br><br><a href=" + link + ">Reset password link</a>";

            }
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)

            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

                smtp.Send(message);

        }
    }
}