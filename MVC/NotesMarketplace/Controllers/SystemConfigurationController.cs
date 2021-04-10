﻿using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
    public class SystemConfigurationController : Controller
    {
        // GET: SystemConfiguration
        Sample_1Entities15 dbObj = new Sample_1Entities15();
        public ActionResult Configuration(SystemConfiguration obj)
        {
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddConfiguration(SystemConfiguration model)
        {

            

            SystemConfiguration obj = new SystemConfiguration();
            if (ModelState.IsValid)
            {

              


                obj.ID = model.ID;
                obj.SupportEmailAddress = model.SupportEmailAddress;
                obj.SupportPhoneNumber = model.SupportPhoneNumber;
                obj.IsActive = true;
                obj.EmailAddress = model.EmailAddress;
                obj.FacebookURL = model.FacebookURL;
                obj.TwitterURL = model.TwitterURL;
                obj.LinkedInURL = model.LinkedInURL;
               


                if (model.ID == 0)
                {

                    dbObj.SystemConfigurations.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Configuration");
        }
    }
}