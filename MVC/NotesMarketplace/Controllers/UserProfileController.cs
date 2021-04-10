
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
            ;
            return View(obj);
        }


        [HttpPost]
        public ActionResult AddProfile(UserProfile model/*,HttpPostedFileBase ImageFile*/)
        {
         /*   string fileName = System.IO.Path.GetFileName(ImageFile.FileName);

            //Set the Image File Path.
            string filePath = "~/Image/" + fileName;

            Response.Write(filePath);

            //Save the Image File in Folder.
            ImageFile.SaveAs(Server.MapPath(filePath));

            //Insert the Image File details in Table.
           /* Sample_1Entities10 dbObj = new Sample_1Entities10(); 
            dbObj.UserProfiles.Add(new UserProfile
            {
                
                ProfilePicture = filePath
            });
            dbObj.SaveChanges();*/


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
                model.ProfilePicture =  fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageFile.SaveAs(fileName);


                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                obj.ID = model.ID;
                obj.UserID = Convert.ToInt32(Session["ID"]);
                obj.DOB= model.DOB;
                
                obj.Gender = model.Gender;
               
                obj.CountryCode = model.CountryCode;
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
                obj.CreatedBy = 1;
                obj.CreatedDate = model.CreatedDate;
                obj.ModifiedBy = 1;
                obj.ModifiedDate = model.ModifiedDate;
              
                if (model.ID == 0)
                {
                    Response.Write(obj.ProfilePicture);
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

        public ActionResult MyProfile(UserProfile obj1)
        {
            return View(obj1);
        }

        [HttpPost]
        public ActionResult AddMyProfile( UserProfile model)
        {

            

            UserProfile obj1 = new UserProfile();
            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension1 = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension1;
                model.ProfilePicture = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageFile.SaveAs(fileName);
                

                obj1.ID = model.ID;
                obj1.UserID = Convert.ToInt32(Session["ID"]);
               
                obj1.SecondaryEmailAddress = model.SecondaryEmailAddress;
           
                obj1.CountryCode = model.CountryCode;
                obj1.PhoneNumber = model.PhoneNumber;
                //obj1.ProfilePicture = model.ProfilePicture;
               


                if (model.ID == 0)
                {

                    dbObj.UserProfiles.Add(obj1);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj1).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("MyProfile");
        }
    }
}