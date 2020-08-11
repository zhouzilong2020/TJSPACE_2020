using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using TJSpace.DBModel;

namespace TJSpace.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public SearchController(DataDBContext context)
        {
            dbContext = context;
        }

        //检索教师信息
        //GET
        [HttpGet]
        public ActionResult<string> SearchTeacher([FromBody]string name)
        {
            List<Teacher> list = dbContext.Teachers.Where(n => n.Name.Equals(name)).ToList();
            var info = dbContext.Teachers.Where(n => n.Name.Equals(name)).ToList().FirstOrDefault();

            if (info == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "不存在该名老师"
                });
            }
            return Ok(new
            {
                status = true,
                data = list,
                msg = "检索成功"
            });
        }

        //检索教师开设课程
        //GET
        [HttpGet]
        public ActionResult<string> SearchTeaches([FromBody]string name)
        {

            var info1 = dbContext.Teachers.Where(n => n.Name.Equals(name)).ToList().FirstOrDefault();

            if (info1 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "不存在该名老师"
                });
            }
            string teacherid = info1.TeacherId;

            List<Teaches> courseInfo = dbContext.Teaches.Where(n => n.TeacherId.Equals(teacherid)).ToList();

            var info2 = dbContext.Teaches.Where(n => n.TeacherId.Equals(teacherid)).ToList().FirstOrDefault();
            if (info2 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "该名老师未开课"
                });
            }
            string courseid = info2.CourseId;

            var info3 = dbContext.CourseCodes.Where(n => n.CourseId.Equals(courseid)).ToList().FirstOrDefault();

            return Ok(new
            {
                status = true,
                data_1 = courseInfo,
                data_2 = info3.Title,
                msg = "检索成功"
            });
        }

        //查找课程
        [HttpGet]
        public ActionResult<string> SearchCourse([FromBody] string keywords)
        {
            var info1 = dbContext.CourseCodes.Where(u => u.Title == keywords).ToList().FirstOrDefault();
            if (info1 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找课程失败,该课程不存在"
                });
            }
            string courseId = info1.CourseId;

            var info2 = dbContext.Courses.Where(u => u.CourseId == courseId).ToList().FirstOrDefault();
            if (info2 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找课程失败,不存在该课程信息"
                });
            }

            var info3 = dbContext.Teaches.Where(u => u.CourseId == courseId).ToList();
            if (info3 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找课程失败,不存在教师教授该课程"
                });
            }

            List<SearchCourseReturn> list = new List<SearchCourseReturn>();
            foreach (var r in info3)
            {
                var teacher_temp = dbContext.Teachers.Where(u => u.TeacherId == r.TeacherId).ToList().FirstOrDefault();
                if (teacher_temp != null)
                {
                    list.Add(new SearchCourseReturn { TeacherName = teacher_temp.Name, Semester = r.Semester, Year = r.Year });
                }
            }

            return Ok(new
            {
                CourseName = info1.Title,//课程名
                CourseCredit = info2.Credits,
                CourseId = info1.CourseId,
                TeacherInfo = list,
                status = true,
                msg = "查找课程成功"
            });
        }

        //查找帖子，目前是只能查找指定字符，待修改为查找范围字符
        [HttpGet]
        public ActionResult<string> SearchPost([FromBody] string keywords)
        {
            var info = dbContext.Posts.Where(u => u.Title == keywords).ToList();

            if (info.Count == 0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找帖子失败,该帖子不存在"
                });
            }

            List<SearchPostReturn> list = new List<SearchPostReturn>();

            foreach (var r in info)
            {
                var _user = dbContext.Users.Where(u => u.UserId == r.UserId).ToList().FirstOrDefault();
                list.Add(new SearchPostReturn { Title = r.Title, Name = _user.NickName, Date = r.Date, PostId = r.PostId });
            }

            return Ok(new
            {
                Post = list,
                status = true,
                msg = "查找帖子成功"
            });
        }

        public class SearchCourseReturn
        {
            public string TeacherName { get; set; }
            public int Semester { get; set; }
            public int Year { get; set; }
        }

        public class SearchPostReturn
        {
            public string PostId { get; set; }//帖子id
            public string Title { get; set; }//帖子名称
            public DateTime Date { get; set; }//帖子标题
            public string Name { get; set; }//发帖人
        }
    }
}
