using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.context;

namespace WebApplication3.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Sample_1Entities1 dbObj = new Sample_1Entities1();
        public ActionResult Index(contact_us obj)
        {
            
                return View(obj);
           
        }

        [HttpPost]
        public ActionResult AddInfo(contact_us model)
        {

            if (ModelState.IsValid)
            {
                contact_us obj = new contact_us();
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.EmailID = model.EmailID;
                obj.Subject = model.Subject;
                obj.Comments = model.Comments;

                if (model.ID == 0)
                {

                    dbObj.contact_us.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Index");
        }

        public ActionResult StudentList()
        {
            var res = dbObj.contact_us.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.contact_us.Where(x => x.ID == id).First();
            dbObj.contact_us.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.contact_us.ToList();

            return View("StudentList",list);
        }
        
    }
}