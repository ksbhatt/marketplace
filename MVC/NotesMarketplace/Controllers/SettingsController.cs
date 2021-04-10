using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
    public class SettingsController : Controller
    {
        // GET: Settings
        


        Sample_1Entities25 dbObj = new Sample_1Entities25();

        public ActionResult Category(NoteCategory obj)
        {
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddCategory(NoteCategory model)
        {
            NoteCategory obj = new NoteCategory();
            if (ModelState.IsValid)
            {

                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Description = model.Description;
                obj.IsActive = true;
                obj.CreatedBy = model.CreatedBy;


                if (model.ID == 0)
                {

                    dbObj.NoteCategories.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Category");
        }

        public ActionResult ManageCategory()
        {
            var res = dbObj.NoteCategories.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbObj.NoteCategories.Where(x => x.ID == id).First();
            dbObj.NoteCategories.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.NoteCategories.ToList();

            return View("ManageCategory", list);
        }

        Sample_1Entities18 dbObj1 = new Sample_1Entities18();

        public ActionResult Type(NoteType obj1)
        {
            return View(obj1);
        }

        [HttpPost]
        public ActionResult AddType(NoteType model)
        {
            NoteType obj1 = new NoteType();
            if (ModelState.IsValid)
            {

                obj1.ID = model.ID;
                obj1.Name = model.Name;
                obj1.Description = model.Description;
                obj1.IsActive = true;
                obj1.CreatedBy = model.CreatedBy;


                if (model.ID == 0)
                {

                    dbObj1.NoteTypes.Add(obj1);
                    dbObj1.SaveChanges();
                }
                else
                {
                    dbObj1.Entry(obj1).State = System.Data.Entity.EntityState.Modified;
                    dbObj1.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Type");
        }

        public ActionResult ManageType()
        {
            var res1 = dbObj1.NoteTypes.ToList();
            return View(res1);
        }
        public ActionResult DeleteType(int id1)
        {
            var res1 = dbObj1.NoteTypes.Where(x => x.ID == id1).First();
            dbObj1.NoteTypes.Remove(res1);
            dbObj1.SaveChanges();

            var list1 = dbObj1.NoteTypes.ToList();

            return View("ManageType", list1);
        }

        Sample_1Entities20 dbObj2 = new Sample_1Entities20();

        public ActionResult Country(Country obj2)
        {
            return View(obj2);
        }

        [HttpPost]
        public ActionResult AddCountry(Country model)
        {
            Country obj2 = new Country();
            if (ModelState.IsValid)
            {

                obj2.ID = model.ID;
                obj2.Name = model.Name;
                obj2.Countrycode = model.Countrycode;
                obj2.IsActive = true;
                obj2.CreatedBy = model.CreatedBy;


                if (model.ID == 0)
                {

                    dbObj2.Countries.Add(obj2);
                    dbObj2.SaveChanges();
                }
                else
                {
                    dbObj2.Entry(obj2).State = System.Data.Entity.EntityState.Modified;
                    dbObj2.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Country");
        }

        public ActionResult ManageCountry()
        {
            var res2 = dbObj2.Countries.ToList();
            return View(res2);
        }
        public ActionResult DeleteCountry(int id2)
        {
            var res2 = dbObj2.Countries.Where(x => x.ID == id2).First();
            dbObj2.Countries.Remove(res2);
            dbObj2.SaveChanges();

            var list2 = dbObj2.Countries.ToList();

            return View("ManageCountry", list2);
        }

        Sample_1Entities1 dbObj3 = new Sample_1Entities1();

        public ActionResult Admin(User obj3)
        {
            return View(obj3);
        }

        [HttpPost]
        public ActionResult AddAdmin(User model)
        {
            User obj3 = new User();
            if (ModelState.IsValid)
            {
               
                obj3.ID = model.ID;
                obj3.FirstName = model.FirstName;
                obj3.LastName = model.LastName;
                obj3.EmailID = model.EmailID;
                obj3.PhoneNo = model.PhoneNo;
                obj3.CreatedDate = model.CreatedDate;
                obj3.IsActive = model.IsActive;
                

                if (model.ID == 0)
                {

                    dbObj3.Users.Add(obj3);
                    dbObj3.SaveChanges();
                }
                else
                {
                    dbObj3.Entry(obj3).State = System.Data.Entity.EntityState.Modified;
                    dbObj3.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Admin");
        }

        public ActionResult ManageAdmin()
        {
            var res3 = dbObj3.Users.ToList();
            return View(res3);
        }
        public ActionResult DeleteAdmin(int id3)
        {
            var res3 = dbObj3.Users.Where(x => x.ID == id3).First();
            dbObj3.Users.Remove(res3);
            dbObj3.SaveChanges();

            var list3 = dbObj3.Users.ToList();

            return View("ManageAdmin", list3);
        }



    }
}