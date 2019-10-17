using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace lab_49_MVC_core_users_categories_todoitems
{


    public partial class ToDoItemModel : DbContext
    {
        public ToDoItemModel(DbContextOptions<ToDoItemModel> options)
            : base(options)
        {
           // Database.EnsureDeleted();
          //  Database.EnsureCreated();
           
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ToDoItem> ToDoItems { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDoItem>()
                .Property(e => e.Item)
                .IsUnicode(false);

            // one category relates to many TODO items
            builder.Entity<Category>().HasMany(t => t.ToDoItems).WithOne(c => c.Category);

            // categoryname to be seen in lookups for category : ENFORCE NAME
            builder.Entity<Category>().Property(c => c.CategoryName).IsRequired();

            // one user : many todo
            builder.Entity<User>().HasMany(t => t.ToDoItems).WithOne(u => u.User);
            // enforce user name
            builder.Entity<User>().Property(u => u.UserName).IsRequired();

            // other way around : One TODO ITEM 
            builder.Entity<ToDoItem>().HasOne(c => c.Category).WithMany(t => t.ToDoItems);
            builder.Entity<ToDoItem>().HasOne(u => u.User).WithMany(t => t.ToDoItems);

            // description required
            builder.Entity<ToDoItem>().Property(t => t.Item).IsRequired();

        }
    }
}
