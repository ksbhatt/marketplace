using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class ARejectedController : Controller
    {
        Sample_1Entities25 dbObj = new Sample_1Entities25();
        // GET: ARejected
        public ActionResult ARejected()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<NoteCategory> notecategories = db.NoteCategories.ToList();
                List<User> users = db.Users.ToList();
                List<User> ausers = db.Users.ToList();

                var arejectednotes = from s in sellernotes
                                    where s.Status == 2
                                    join c in notecategories on s.Category equals c.ID into table1
                                    from c in table1.ToList()
                                     join u in users on s.SellerID equals u.ID into table2
                                     from u in table2.ToList()
                                     join u1 in ausers on s.ActionedBy equals u1.ID into table3
                                     from u1 in table3.ToList()
                                     select new APublishedModel
                                     {
                                        sellernote = s,
                                         user = u,
                                         auser=u1,
                                         notecategory = c
                                     
                                    };
                return View(arejectednotes);

            }
        }
    }
}