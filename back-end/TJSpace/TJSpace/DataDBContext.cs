using System;
using Microsoft.EntityFrameworkCore;
using TJSpace.DBModel;

namespace TJSpace
{
    public class DataDBContext:DbContext
    {
        public DataDBContext(DbContextOptions<DataDBContext> options)
            :base(options)
        {
        }

       public DbSet<Account> Accounts { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Course> Courses { get; set; }
       public DbSet<CourseCode> CourseCodes { get; set; }
       public DbSet<Credibility> Credibilities { get; set; }
       public DbSet<Major> majors { get; set; }
       public DbSet<Mark> marks { get; set; }
       public DbSet<Post> Posts { get; set; }
       public DbSet<Reply> Replies { get; set; }
       public DbSet<SendMessage> SendMessages { get; set; }
       public DbSet<Takes> Takes { get; set; }
       public DbSet<Teacher> Teachers { get; set; }
       public DbSet<Teaches> Teaches { get; set; }
       public DbSet<User> Users { get; set; }
       
    }
}
