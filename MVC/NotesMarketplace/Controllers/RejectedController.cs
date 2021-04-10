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
    public class RejectedController : Controller
    {
        Sample_1Entities25 dbObj = new Sample_1Entities25();
        // GET: Rejected
        public ActionResult RejectedNotes()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<NoteCategory> notecategories = db.NoteCategories.ToList();

                var rejectednotes = from s in sellernotes
                                where s.Status == 2 
                                join c in notecategories on s.Category equals c.ID into table1
                                from c in table1.ToList()

                                select new RejectedModel
                                {
                                    sellernote = s,
                                    notecategory = c

                                };
                return View(rejectednotes);


                /*var results = (from s in db.SellerNotes
                               where s.Status == 2
                               select s).ToList();
                return View(results);*/

                /*var res = dbObj.SellerNotes.Where(x => x.Status == 2).First(); 
                return View(res);*/
            }

        }
    }
}