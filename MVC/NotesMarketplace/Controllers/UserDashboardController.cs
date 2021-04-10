using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class UserDashboardController : Controller
    {
        Sample_1Entities25 dbobj = new Sample_1Entities25();
        // GET: UserDashboard
        public ActionResult UserDashboard()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<NoteCategory> notecategories = db.NoteCategories.ToList();


                var Frontdashboard = from s in sellernotes
                                     join c in notecategories on s.Category equals c.ID into table1
                                     from c in table1.ToList()
                                     select new DashboardModel
                                     {
                                         sellernote = s,

                                         notecategory = c


                                     };
                return View(Frontdashboard);
            }
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<NoteCategory> notecategories = db.NoteCategories.ToList();


                var Frontdashboard = from s in sellernotes where s.Status==1
                                     join c in notecategories on s.Category equals c.ID into table1
                                     from c in table1.ToList()
                                     select new DashboardModel
                                     {
                                         sellernote = s,

                                         notecategory = c


                                     };
                return View(Frontdashboard);
            }
        }

    }
}