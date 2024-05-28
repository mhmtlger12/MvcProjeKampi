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
            WriterValidator WriterValidation = new WriterValidator();    
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
    }
}