﻿ 
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
    public class NotesController : Controller
    {
        // GET: Notes
        Sample_1Entities11 dbObj = new Sample_1Entities11();
        public ActionResult Notes(SellerNote obj)
        {
            return View(obj);
        }


        [HttpPost]
        public ActionResult AddNotes(SellerNote model,string submit)
        {
            /*ViewBag.Message = "Form submitted.";*/

            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.DisplayPicture = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            model.ImageFile.SaveAs(fileName);

            string fileName1 = Path.GetFileNameWithoutExtension(model.ImageFile1.FileName);
            string extension1 = Path.GetExtension(model.ImageFile1.FileName);
            fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
            model.NotePreview = "~/Image/" + fileName1;
            fileName1 = Path.Combine(Server.MapPath("~/Image/"), fileName1);
            model.ImageFile1.SaveAs(fileName1);
     

            
            String FileExt = Path.GetExtension(model.files.FileName).ToUpper();
            if (FileExt == ".PDF")
            {


                string fileName2 = Path.GetFileNameWithoutExtension(model.files.FileName);
                string extension2 = Path.GetExtension(model.files.FileName);
                fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                model.DisplayNote = "~/PDFs/" + fileName2;
                fileName2 = Path.Combine(Server.MapPath("~/PDFs/"), fileName2);
                model.files.SaveAs(fileName2);
            
            }

        /*string fileName1 = Path.GetFileNameWithoutExtension(model.ImageFile1.FileName);
        string extension1 = Path.GetExtension(model.ImageFile1.FileName);
        fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
        model.NotesPreview = "~/Image/" + fileName1;
        fileName1 = Path.Combine(Server.MapPath("~/Image/"), fileName1);
        model.ImageFile1.SaveAs(fileName1);*/

            SellerNote obj = new SellerNote();
            if (ModelState.IsValid)
            {

                /*foreach (HttpPostedFileBase file in files)
                {

                   

                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Image/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }*/

                obj.ID = model.ID;
                obj.SellerID = 1002;
                //obj.UserID = model.UserID;
                obj.Status = 1;
                obj.ActionedBy = 1002;
                /*obj.SecondaryEmailAddress = model.SecondaryEmailAddress;
                obj.CountryCode = model.CountryCode;*/
                obj.AdminRemarks = "5";
                //obj.DisplayPicture = model.DisplayPicture;
                obj.PublishedDate = model.PublishedDate;
                obj.Title = model.Title ;
                obj.Category = model.Category;
                obj.NoteType = model.NoteType;
                obj.NumberOfPages = model.NumberOfPages;
                obj.Description =model.Description;
                obj.UniversityName = model.UniversityName;
                obj.Country = model.Country;
                obj.Course = model.Course;
                obj.CourseCode = model.CourseCode;
                obj.Professor = model.Professor;
                obj.IsPaid = true;
                obj.SellingPrice = model.SellingPrice;
                obj.IsActive = true;

                if (model.ID == 0)
                {

                    dbObj.SellerNotes.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();

            return View("Notes");
        }
       
       
    }
}