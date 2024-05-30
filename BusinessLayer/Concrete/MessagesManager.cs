using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class MessagesManager:IMessageService
    {
        IMessageDal _messageDal;


        //ctrl+. yaparsan ctor yapar 
        public MessagesManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetList()
        {
            return _messageDal.List(x => x.RecevierMail == "admin@gmail.com");
        }

        public void MessageDelete(Message message)
        {
            
        }

        public void MessageUpdate(Message message)
        {
         
        }

        public void MessageyAdd(Message message)
        {
            
        }
    }
}
