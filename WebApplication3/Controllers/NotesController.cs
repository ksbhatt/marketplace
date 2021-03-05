﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.context;

namespace WebApplication3.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        Sample_1Entities4 dbObj = new Sample_1Entities4();

        public object SellerNoteContext { get; private set; }
        public string FileName { get; private set; }

        public ActionResult Notes(SellerNote obj)
        {
            return View(obj);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
       

        [HttpPost]
        public ActionResult AddNotes(SellerNote model)
        {
        
            if (ModelState.IsValid)
            {
                SellerNote obj = new SellerNote();
                obj.ID = model.ID;
                obj.SellerID = model.SellerID;
                obj.Status = model.Status;
                obj.ActionedBy = model.ActionedBy;
                obj.AdminRemarks = model.AdminRemarks;
                obj.PublishedDate = model.PublishedDate;
                obj.Title = model.Title;
                obj.Category = model.Category;
                obj.DisplayPicture = model.DisplayPicture;
                obj.NoteType = model.NoteType;
                obj.NumberOfPages = model.NumberOfPages;
                obj.Description = model.Description;
                obj.UniversityName = model.UniversityName;
                obj.Country = model.Country;
                obj.Course = model.Course;
                obj.CourseCode = model.CourseCode;
                obj.Professor = model.Professor;
                obj.IsPaid = model.IsPaid;
                obj.SellingPrice = model.SellingPrice;
                obj.NotesPreview = model.NotesPreview;
                obj.CreatedDate = model.CreatedDate;
                obj.CreatedBy = model.CreatedBy;
                obj.ModifiedDate = model.ModifiedDate;
                obj.ModifiedBy = model.ModifiedBy;
                obj.IsActive = model.IsActive;
                obj.UploadNotes = model.UploadNotes;
               
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

            return View("AddNotes");
        }
        public ActionResult AddImages(SellerNote imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.DisplayPicture = "~/Image" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);

            string fileName1 = Path.GetFileNameWithoutExtension(imageModel.ImageFile1.FileName);
            string extension1 = Path.GetExtension(imageModel.ImageFile1.FileName);
            fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
            imageModel.UploadNotes = "~/Image" + fileName1;
            fileName1 = Path.Combine(Server.MapPath("~/Image/"), fileName1);
            imageModel.ImageFile1.SaveAs(fileName1);

            string fileName2 = Path.GetFileNameWithoutExtension(imageModel.ImageFile2.FileName);
            string extension2 = Path.GetExtension(imageModel.ImageFile2.FileName);
            fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.NotesPreview = "~/Image" + fileName2;
            fileName2 = Path.Combine(Server.MapPath("~/Image/"), fileName2);
            imageModel.ImageFile2.SaveAs(fileName);

            Sample_1Entities4 db = new Sample_1Entities4();
            {
                db.SellerNotes.Add(imageModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }
        public ActionResult NotesList()
        {
            var res = dbObj.SellerNotes.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.SellerNotes.Where(x => x.ID == id).First();
            dbObj.SellerNotes.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.SellerNotes.ToList();

            return View("NotesList", list);
        }

    }
}