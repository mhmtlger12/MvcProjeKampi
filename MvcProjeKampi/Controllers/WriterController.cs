using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
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
    }
}