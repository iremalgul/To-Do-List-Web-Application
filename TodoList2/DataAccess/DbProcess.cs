using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbProcess
    {
        private ToDoListEntities entities;
        public DbProcess()
        {
            entities = new ToDoListEntities();
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
