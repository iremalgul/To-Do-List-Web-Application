
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList2.Models;

namespace TodoList2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public PartialViewResult GridViewPartial()
        {
            DbProcess dbProcess = new DbProcess();  
     
            return PartialView(dbProcess.GetAllTodos());
        }
      

        public ActionResult ToDoList()
        {

            return View();
        }

        public ActionResult Submit(string name, bool isComplete, string process, int myId = 0)
        {
            if (process == "insert")
            {
                ToDoListEntities1 entities = new ToDoListEntities1();
                ToDo todo = new ToDo()
                {
                    Description = name,
                    IsCompleted = isComplete,
                    CreateDate = DateTime.Now,
                    CreatedUserId = 1

                };
                entities.ToDo.Add(todo);
                entities.SaveChanges();
            }
            else if (process == "update")
            {
                ToDoListEntities1 entities = new ToDoListEntities1();

                var toDo = entities.ToDo.FirstOrDefault(x => x.Id == myId);
                if (toDo != null)
                {
                    toDo.Description = name;
                    toDo.IsCompleted = isComplete;
                    toDo.UpdatedUserId = 1;
                    toDo.UpdateDate = DateTime.Now;
                }
                entities.SaveChanges();
            }
            else
            {

                ToDoListEntities1 entities = new ToDoListEntities1();
                var toDo = entities.ToDo.FirstOrDefault(x => x.Id == myId);

                if (toDo != null)
                {
                    entities.ToDo.Remove(toDo);
                    entities.SaveChanges();
                }
            }
            return Json(new JsonModel { isSuccess = true, Message = "İşlem başarılı" }, JsonRequestBehavior.AllowGet);
        }
    }



}