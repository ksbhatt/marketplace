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
    public class DownloadController : Controller
    {
        // GET: Download
        Sample_1Entities25 dbObj = new Sample_1Entities25();
        
            public ActionResult DownloadedNotes()
            {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                //var v = db.Downloads.Where(a => a.IsSellerHasAllowedDownload == false).FirstOrDefault();

                List<Download> downloads = db.Downloads.ToList();
                List<User> users = db.Users.ToList();
                List<SellerNote> sellernotes = db.SellerNotes.ToList();

                var downloadnotes = from d in downloads
                                   where d.IsSellerHasAllowedDownload == true && d.Downloader == Convert.ToInt32(Session["ID"])
                                   join u in users on d.Downloader equals u.ID into table1
                                   from u in table1.ToList()
                                    join s in sellernotes on d.NoteID equals s.ID into table2
                                    from s in table2.ToList()
                                    select new DownloadModel
                                   {
                                       user = u,
                                       download = d,
                                       sellernote=s
                                   };
                return View(downloadnotes);

            }
        }

        public ActionResult NoteDetails(int id)
        {

            Sample_1Entities25 dc1 = new Sample_1Entities25();
            {

                int ID = id;
                var n = dc1.SellerNotes.Where(a => a.ID == id).FirstOrDefault();

                SellerNote seller = new SellerNote
                {
                    Title = n.Title,

                    UniversityName = n.UniversityName,
                    Country = n.Country,
                    Course = n.Course,
                    CourseCode = n.CourseCode,
                    Professor = n.Professor,
                    NumberOfPages = n.NumberOfPages,
                    ModifiedDate = n.ModifiedDate,
                    Description = n.Description,
                    AdminRemarks = n.AdminRemarks,
                    DisplayPicture = n.DisplayPicture,
                    DisplayNote = n.DisplayNote
                };
                ViewBag.Message = seller;


            }

            return View();
        }

    }
}