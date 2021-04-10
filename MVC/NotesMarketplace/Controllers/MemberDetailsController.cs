using NotesMarketplace.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotesMarketplace.Controllers
{
    public class MemberDetailsController : Controller
    {
        
        // GET: MemberDetails
        public ActionResult MemberDetails(int id)
        {
            Sample_1Entities10 dc1 = new Sample_1Entities10() ;
            {
                UserProfile model = new UserProfile();
                model.ID = id;
                int ID = id;
                var n = dc1.UserProfiles.Where(a => a.ID == id).FirstOrDefault();

                UserProfile user = new UserProfile
                {   
                    DOB = n.DOB,
                    PhoneNumber=n.PhoneNumber,
                    College=n.College,
                    University=n.University,
                    AddressLine1=n.AddressLine1,
                    AddressLine2=n.AddressLine2,
                    City=n.City,State=n.State,
                    Country=n.Country,
                    Zipcode=n.Zipcode
                };
                ViewBag.Message = user;


            }

            return View();
        }
    }
}