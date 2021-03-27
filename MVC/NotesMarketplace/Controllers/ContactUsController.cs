
using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NotesMarketplace.Controllers
{

    [SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
    public class ContactUsController : Controller
    {
        /*Sample_1Entities1 dbObj1 = new Sample_1Entities1();
        [HttpGet]
        public ActionResult Demo()
        {
            var res = dbObj1.Users.ToList();
            return View(res);

            /*if (Session["EmailID"] != null)
            {
                return RedirectToAction("SearchNotes", "Signup", new { ID = Session["ID"].ToString() });
            }
            else
            {
            
            
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Demo(User login)
        {
            
            
            Sample_1Entities1 dc = new Sample_1Entities1();
            {

                var v = dc.Users.Where(a => a.ID == Session["ID"]).FirstOrDefault();
                if (v != null)
                {
                    Session["ID"] = v.ID.ToString();
                    Session["EmailID"] = v.EmailID.ToString();
                    Session["FullName"] = v.FirstName.ToString() + v.LastName.ToString;
                }
                return View();
            }

        }*/

        // GET: ContactUs
        Sample_1Entities3 dbObj = new Sample_1Entities3();
        public ActionResult ContactUs(contact_us obj)
        {


            return View(obj);
        }
      

        [HttpPost]
        public ActionResult AddUser(contact_us model)
        {
            contact_us obj = new contact_us();
            if (ModelState.IsValid)
            {
               
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

            return View("ContactUs");
        }

        public ActionResult UserList()
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

            return View("UserList", list);
        }

    }
}
    
