using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class ReportController : Controller
    {
        Sample_1Entities25 dbObj = new Sample_1Entities25();
        // GET: Report
        public ActionResult Report()
        {
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                List<User> users = db.Users.ToList();
                List<Download> downloads = db.Downloads.ToList();
                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<SellerNotesReportedIssue> sellernotesreportedissues = db.SellerNotesReportedIssues.ToList();

                var employeeRecord = from sr in sellernotesreportedissues
                                     join d in downloads on sr.AgainstDownloadID equals d.ID into table1
                                     from d in table1.ToList()
                                     join s in sellernotes on sr.NoteID equals s.ID into table2
                                     from s in table2.ToList()
                                     join u in users on sr.ReportedByID equals u.ID into table3
                                     from u in table3.ToList()
                                     select new ViewModel
                                     {
                                         user = u,
                                         download = d,
                                         sellernote = s,
                                         sellernotesreportedissues = sr
                                     };
                return View(employeeRecord);

            }
            
        }

        
        public ActionResult Delete(int id)
        {

            /*try
            {
                ViewModel EmpRepo = new ViewModel();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("Report");

            }
            catch
            {
                return View("Report");
            }*/
           
                var res = dbObj.SellerNotesReportedIssues.Where(x => x.ID == id).First();
                dbObj.SellerNotesReportedIssues.Remove(res);
                dbObj.SaveChanges();

                //var list = dbObj.SellerNotesReportedIssues.ToList();
            using (Sample_1Entities25 db = new Sample_1Entities25())
            {
                List<User> users = db.Users.ToList();
                List<Download> downloads = db.Downloads.ToList();
                List<SellerNote> sellernotes = db.SellerNotes.ToList();
                List<SellerNotesReportedIssue> sellernotesreportedissues = db.SellerNotesReportedIssues.ToList();

                var employeeRecord = from sr in sellernotesreportedissues
                                     join d in downloads on sr.AgainstDownloadID equals d.ID into table1
                                     from d in table1.ToList()
                                     join s in sellernotes on sr.NoteID equals s.ID into table2
                                     from s in table2.ToList()
                                     join u in users on sr.ReportedByID equals u.ID into table3
                                     from u in table3.ToList()
                                     select new ViewModel
                                     {
                                         user = u,
                                         download = d,
                                         sellernote = s,
                                         sellernotesreportedissues = sr
                                     };
                return View("Report",employeeRecord);
            }

          //  return View("Report");
            }
        }
    }
