using System.Collections.Generic;
using System;
using System.Linq;

namespace TodoList2.Controllers
{
    public class DbProcess
    {
        
             private ToDoListEntities1 entities;
        public DbProcess()
        {
            entities = new ToDoListEntities1();
        }
        public void InsertTodo(string name, bool isComplete, int myId = 0)
        {
            ToDo toDo = new ToDo()
            {
                CreateDate = DateTime.Now,
                CreatedUserId = 1,
                Description = name,
                IsCompleted = isComplete,
            };
            entities.ToDo.Add(toDo);
            entities.SaveChanges();
        }
        public void UpdateTodo(string name, bool isComplete, int myId)
        {
            var todo = entities.ToDo.Find(myId);
            todo.IsCompleted = isComplete;
            todo.Description = name;
            todo.UpdateDate = DateTime.Now;
            todo.CreatedUserId = 1;
            entities.SaveChanges();
        }
        public void DeleteTodo(int id)
        {
            var todo = entities.ToDo.Find(id);
            entities.ToDo.Remove(todo);
            entities.SaveChanges();
        }
        public List<ToDo> GetAllTodos()
        {
            return entities.ToDo.ToList();
        }
    }
 }
