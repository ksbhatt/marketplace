using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class MembersController : Controller
    {
        Sample_1Entities25 dbObj = new Sample_1Entities25();
        // GET: Members
        public ActionResult Members()
        {

            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                List<User> users = db.Users.ToList();


                var members = (from u in db.Users

                               select u).ToList();
                return View(members);
            }
        }
    }
}