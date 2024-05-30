using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessagesManager cm = new MessagesManager(new EfMessageDal());

        public ActionResult Inbox()
        {
            var messagelist = cm.GetList();
            return View(messagelist);
        }
    }
}