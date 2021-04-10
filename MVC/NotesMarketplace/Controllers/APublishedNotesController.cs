using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class APublishedNotesController : Controller
    {
        Sample_1Entities25 dbobj = new Sample_1Entities25();
        // GET: APublishedNotes
        public ActionResult APublishedNotes()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                //var v = db.Downloads.Where(a => a.IsSellerHasAllowedDownload == false).FirstOrDefault();
              
                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<User> users = db.Users.ToList();
                List<User> ausers = db.Users.ToList();
                List<NoteCategory> notecategories = db.NoteCategories.ToList();


                var Apublishednotes = from s in sellernotes
                                     where s.Status == 1
                                     join u in users on s.SellerID equals u.ID into table1
                                     from u in table1.ToList()
                                     join u1 in ausers on s.ActionedBy equals u1.ID into table3
                                     from u1 in table3.ToList()
                                     join c in notecategories on s.Category equals c.ID into table2
                                     from c in table2.ToList()

                                     select new APublishedModel
                                     {
                                         sellernote = s,
                                         user = u,
                                         auser=u1,
                                         notecategory = c


                                     };
                return View(Apublishednotes);
            }
        }
    }
}