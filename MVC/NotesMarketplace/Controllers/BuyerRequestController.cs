using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class BuyerRequestController : Controller
    {
        Sample_1Entities25 dbObj = new Sample_1Entities25();
        // GET: BuyerRequest
        public ActionResult Request()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                //var v = db.Downloads.Where(a => a.IsSellerHasAllowedDownload == false).FirstOrDefault();

                List<Download> downloads = db.Downloads.ToList();
                List<User> users = db.Users.ToList();

                
                var BuyerRequest = from d in downloads where d.IsSellerHasAllowedDownload==false && d.Seller == Convert.ToInt32(Session["ID"])
                                   join u in users on d.Downloader equals u.ID into table1
                                   from u in table1.ToList()

                                   select new RequestModel
                                   {
                                       user = u,
                                       download = d

                                   };
                return View(BuyerRequest);

            }
        }
    }
}