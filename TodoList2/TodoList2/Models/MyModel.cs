using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList2.Models
{
    public class MyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}