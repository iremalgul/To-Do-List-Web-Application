
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList2.Models;

namespace TodoList2.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckUser(string name, string password)
        {
            ToDoListEntities1 entities = new ToDoListEntities1();
            var user = entities.User.FirstOrDefault(x => x.Name == name && x.Password==password);
            if (user != null)
            {
                return Json(new JsonModel { isSuccess = true, Message = "giriş başarılı" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new JsonModel { isSuccess = false, Message = "giriş başarısız" }, JsonRequestBehavior.AllowGet);
        }
    }
}