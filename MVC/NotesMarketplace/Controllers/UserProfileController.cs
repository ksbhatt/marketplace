﻿
using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NotesMarketplace.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        Sample_1Entities10 dbObj = new Sample_1Entities10();
        public ActionResult UserProfile(UserProfile obj)
        {
            return View(obj);
        }


        [HttpPost]
        public ActionResult AddProfile(UserProfile model)
        { 

       

            /*using(Sample_1Entities4 dbObj =new Sample_1Entities4())
            {
                dbObj.UserProfiles.Add(model); 
                dbObj.SaveChanges();
            }
            ModelState.Clear();*/
            
            UserProfile obj = new UserProfile();
            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.ProfilePicture = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageFile.SaveAs(fileName);


                obj.ID = model.ID;
                obj.UserID = Convert.ToInt32(Session["ID"]);
                obj.DOB= model.DOB;
                
                obj.Gender = model.Gender;
                /*obj.SecondaryEmailAddress = model.SecondaryEmailAddress;
                obj.Count
                ryCode = model.CountryCode;*/
                obj.PhoneNumber = model.PhoneNumber;
                obj.ProfilePicture = model.ProfilePicture;
                obj.AddressLine1 = model.AddressLine1;
                obj.AddressLine2 = model.AddressLine2;
                obj.City = model.City;
                obj.State = model.State;
                obj.Zipcode=model.Zipcode;
                obj.Country = model.Country;
                obj.University = model.University;
                obj.College = model.College;
               

                if (model.ID == 0)
                {

                    dbObj.UserProfiles.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("UserProfile");
        }
        public ActionResult UserProfileList()
        {
            var res = dbObj.UserProfiles.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.UserProfiles.Where(x => x.ID == id).First();
            dbObj.UserProfiles.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.UserProfiles.ToList();

            return View("UserProfileList", list);
        }


    }
}