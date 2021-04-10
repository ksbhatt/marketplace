using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class ADownloadedController : Controller
    {
        Sample_1Entities25 dbObj = new Sample_1Entities25();
        // GET: ADownloaded
        public ActionResult ADownloaded()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                //var v = db.Downloads.Where(a => a.IsSellerHasAllowedDownload == false).FirstOrDefault();

                List<Download> downloads = db.Downloads.ToList();
                List<User> users = db.Users.ToList();
                List<User> users1 = db.Users.ToList();


                var adownloadnotes = from d in downloads
                                    
                                    join u in users on d.Downloader equals u.ID into table1
                                    from u in table1.ToList()
                                     join u1 in users1 on d.Seller equals u1.ID into table2
                                     from u1 in table2.ToList()
                                     select new ADownloadedModel
                                    {
                                        user = u,
                                         user1 = u1,
                                         download = d

                                    };
                return View(adownloadnotes);

            }
        }
    }
}