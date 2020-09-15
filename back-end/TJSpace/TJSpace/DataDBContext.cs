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
       public DbSet<CourseCollect> CourseCollect { get; set; }
       public DbSet<Credibility> Credibilities { get; set; }
       public DbSet<CourseGrade> CourseGrades { get; set; }
       public DbSet<Major> Majors { get; set; }
       public DbSet<Mark> Marks { get; set; }
       public DbSet<Post> Posts { get; set; }
       public DbSet<Reply> Replies { get; set; }
       public DbSet<SendMessage> SendMessages { get; set; }
       public DbSet<Takes> Takes { get; set; }
       public DbSet<Teacher> Teachers { get; set; }
       public DbSet<Teaches> Teaches { get; set; }
       public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasKey(t => new { t.CourseId, t.DeptName });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseCollect>().HasKey(t => new { t.CourseId, t.UserId,t.TeacherId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Credibility>().HasKey(t => new { t.CommentId, t.UserId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mark>().HasKey(t => new { t.UserId, t.PostId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Takes>().HasKey(t => new { t.UserId, t.Year,t.Semester,t.CourseId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teaches>().HasKey(t => new { t.CourseId, t.Semester,t.TeacherId });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseGrade>().HasKey(t => new { t.TeacherId, t.CourseId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
