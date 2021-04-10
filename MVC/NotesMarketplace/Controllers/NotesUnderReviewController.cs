using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class NotesUnderReviewController : Controller
    {
        Sample_1Entities25 dbobj = new Sample_1Entities25();
        // GET: NotesUnderReview
        public ActionResult UnderReview()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                //var v = db.Downloads.Where(a => a.IsSellerHasAllowedDownload == false).FirstOrDefault();

                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<User> users = db.Users.ToList();
                List<NoteCategory> notecategories = db.NoteCategories.ToList();


                var underreview = from s in sellernotes
                                
                                      join u in users on s.SellerID equals u.ID into table1
                                      from u in table1.ToList()
                                      
                                      join c in notecategories on s.Category equals c.ID into table2
                                      from c in table2.ToList()

                                      select new PublishedModel
                                      {
                                          sellernote = s,
                                          user = u,
                                   
                                          notecategory = c


                                      };
                return View(underreview);
            }
        }
    }
}