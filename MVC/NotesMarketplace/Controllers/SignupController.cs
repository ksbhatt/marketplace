﻿

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NotesMarketplace.context;
using System.Web.SessionState;
using PagedList;
using PagedList.Mvc;


namespace NotesMarketplace.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class SignupController : Controller
    {
        public string ReturnUrl { get; private set; }

        private DB_Entities _db = new DB_Entities();
        // GET: Home
        /*public ActionResult IndexForSignup()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        */

        [HttpGet]
        public ActionResult Signup()
        {
           
            
                return View();
            

        }

        // GET: Signup


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Exclude = "IsEmailVerified,IsActive")] User user)
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
                user.RoleID = 1;

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

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;

            Sample_1Entities1 dc = new Sample_1Entities1();
            {
                dc.Configuration.ValidateOnSaveEnabled = false;
                var v = dc.Users.Where(a => a.IsActive == true).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;

                }
                else
                {
                    ViewBag.Message = "Invalid Reuest";
                }
            }
            ViewBag.Status = true;
            return View();

        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["EmailID"] != null)
            {
                return RedirectToAction("SearchNotes", "Signup", new { ID = Session["ID"].ToString() });
            }
            else
            {
                return View();
            }
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User login, string ReturnUrl = "")
        {
            string message = "";
            Sample_1Entities1 dc = new Sample_1Entities1();
            {
                var v = dc.Users.Where(a => a.EmailID == login.EmailID && a.Password == login.Password && a.RoleID == 1).FirstOrDefault();
                var k = dc.Users.Where(a => a.EmailID == login.EmailID && a.Password == login.Password &&  a.RoleID == 0).FirstOrDefault();
                if (v != null)
                {
                    Session["ID"] = v.ID.ToString();
                    Session["EmailID"] = v.EmailID.ToString();
                    Session["FullName"] = v.FirstName + " " + v.LastName;
                    Session["FirstName"] = v.FirstName;
                    Session["LastName"] = v.LastName;

                    return RedirectToAction("SearchNotes");



                    if (string.Compare(login.Password, v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525660 : 20;
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("SearchNotes", "Signup");

                        }
                    }
                    else
                    {
                        message = "Invalid creadential provided";
                    }
                }
                else if (k != null)
                {
                    if (string.Compare(login.Password, k.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525660 : 20;
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {

                            return RedirectToAction("Dashboard", "Signup");

                        }
                    }
                    else
                    {
                        message = "Invalid creadential provided";
                    }
                }
                else
                {
                    message = "Invalid creadential provided";
                }
            }


            ViewBag.Message = message;
            return View();
        }

        Sample_1Entities11 dbObj = new Sample_1Entities11();
        public ActionResult SearchNotes(string ID,string searchBy,string search,int? page)
        {

            if (searchBy == "Title")
            {
                return View(dbObj.SellerNotes.Where(x => x.Title == search || search == null).ToList().ToPagedList(page ?? 1, 9));
            }
            else
            {
                return View(dbObj.SellerNotes.Where(x => x.Course.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 9));
            }

            var res = dbObj.SellerNotes.ToList();
            return View(res);

            /*if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Signup");
            }
            else
            {
                ViewBag.ID = ID;*/
            return View();
            
        }

        /*public ActionResult ContactUs(string ID)
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            /*if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Signup");
            }
            else
            {
                ViewBag.ID = ID;
                return View();
            }
        }*/


        public ActionResult Dashboard(string ID)
        {

            ViewBag.ID = ID;
            return View();

            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Signup");
            }
            else
            {
                ViewBag.ID = ID;
                return View();
            }
        }


        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        /*FormsAuthentication.SignOut();
        return RedirectToAction("Login", "User");*/



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

            var fromEmail = new MailAddress("yourmail@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "yourpassword";
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
                UseDefaultCredentials = false,
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



        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            string message = "";
            bool status = false;

            Sample_1Entities1 dc = new Sample_1Entities1();
            try
            {
                var account = dc.Users.Where(a => a.EmailID == EmailID).FirstOrDefault();
                if (account != null)
                {
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.EmailID, resetCode, "ResetPassword");
                    account.ConfirmPassword = resetCode;

                    dc.Configuration.ValidateOnSaveEnabled = false;

                    dc.SaveChanges();
                    message = "reset password link has been sent to youe emailid";
                }
                else
                {
                    message = "Account not found";
                }
            }
            finally
            {
                Dispose();
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(string id)
        {
            Sample_1Entities1 dc = new Sample_1Entities1();
            {
                var user = dc.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                Sample_1Entities1 dc = new Sample_1Entities1();

                var user = dc.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    user.Password = model.NewPassword;
                    user.ResetPasswordCode = "";
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    message = "new password updated";
                }

                else
                {
                    message = "something invalid";
                }

            }

            ViewBag.Message = message;
            return View(model);

        }
    }
}