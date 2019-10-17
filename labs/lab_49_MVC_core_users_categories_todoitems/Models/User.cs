using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace lab_49_MVC_core_users_categories_todoitems
{



    public partial class User
    {
       
        public User()
        {
            ToDoItems = new HashSet<ToDoItem>();
        }

        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }


         public DateTime LastLoggedIn { get; set; }
       
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
