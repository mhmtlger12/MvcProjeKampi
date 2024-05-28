using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator WriterValidation = new WriterValidator();
        public ActionResult Index()
        {
            //Listeleme işlemini yapıyoruz
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
        //Yazar ekleme işlemi
        [HttpGet]
        public ActionResult AddWriter()
        {
                return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
      
            ValidationResult results=WriterValidation.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");   
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //Yazar ekleme işlemi
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue=wm.GetByID(id);
            return View(writervalue);   
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = WriterValidation.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}