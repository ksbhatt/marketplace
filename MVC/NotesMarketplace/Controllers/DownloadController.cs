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
        Sample_1Entities13 dbObj = new Sample_1Entities13();
        
            public ActionResult DownloadedNotes()
            {

            
            var res = dbObj.Downloads.ToList();
                return View(res);
            }

        
    }
}