using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace lab_48_api_todo_list_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaskItemContext>();
            // (options => options.UseSqlite("Data Source=ToDoDatabase.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }



    public class User
    {

        public int UserId { get; set; }
        public string UserName { get; set; }


    }


    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


    }




    public class TaskItem
    {
        public int TaskItemId { get; set; }
        // data annotations
        [Required]
        public string Description { get; set; }
        public bool? TaskDone { get; set; }

        [Display(Name = "Date Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateDue { get; set; }

        //FOREIGN KEY   int? means NULLABLE INTEGER SO FIELD CAN BE NULL AND WON'T CAUSE EXCEPTION 
        public int? UserId { get; set; }   // FIELD
        public virtual User User { get; set; }  // TABLE

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }

    public class TaskItemContext : DbContext {

        private static bool _dbCreated = false;
        public TaskItemContext()
        {
            if (!_dbCreated)
            {
                _dbCreated = true;
             //  Database.EnsureDeleted();
            //   Database.EnsureCreated();
                Console.WriteLine("test data to CONSOLE");
                Debug.WriteLine("This is debug data");
                Trace.WriteLine("test data to OUTPUT WINDOW");
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source=ToDoDatabase.db");
        }

        // seed the database
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new { CategoryId=1,CategoryName="Admin"},
                new { CategoryId=2,CategoryName="Work"},
                new {CategoryId=3,CategoryName="Training"}
                );
            builder.Entity<User>().HasData(
                new {UserId=1,UserName="Spartan01"},
                new {UserId=2,UserName="Fred"},
                new {UserId=3,UserName="Paul"}
                );
            builder.Entity<TaskItem>().HasData(
                new {TaskItemId=1,Description="Some Item",DateDue=DateTime.Parse("12/12/2019"),done=false,UserId=1,CategoryId=1},
                new {TaskItemId=2,Description="Another Item",DateDue=DateTime.Parse("12/09/2019"),done=false,UserId=2,CategoryId=2},
                new {TaskItemId=3,Description="And This Item",DateDue=DateTime.Parse("12/08/2019"),done=false,UserId=3,CategoryId=3}
                );

        }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
