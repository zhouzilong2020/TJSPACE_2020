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
        public ActionResult<string> SearchTeacher(string name)
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
        public ActionResult<string> SearchTeaches(string name)
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

        //查找课程,包含关键字即可
        [HttpGet]
        public ActionResult<string> SearchCourse(string keywords)
        {
            List<SearchCourseReturn> list = new List<SearchCourseReturn>();

            var info1 = dbContext.CourseCodes.Where(u => u.Title.Contains(keywords)).ToList();
            if (info1.Count()==0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找课程失败,无相关课程"
                });
            }

            foreach(var r in info1)
            {
                SearchCourseReturn s = new SearchCourseReturn();
                var id = r.CourseId;
                var info2 = dbContext.Courses.Where(u => u.CourseId == r.CourseId).ToList().FirstOrDefault();
                if (info2 == null)
                {
                    continue;
                }
                s.CourseName = r.Title;
                s.CourseCredit = info2.Credits;
                s.CourseId = r.CourseId;
                s.CourseIntro = info2.Intro;

                var info3 = dbContext.Teaches.Where(u => u.CourseId == r.CourseId).ToList();
                List<SearchCourseInfo> list1 = new List<SearchCourseInfo>();
                foreach (var t in info3)
                {
                    SearchCourseInfo info4 = new SearchCourseInfo();
                    var teacherId = t.TeacherId;
                    var info5=dbContext.Teachers.Where(u => u.TeacherId == teacherId).ToList().FirstOrDefault();
                    info4.TeacherName = info5.Name;
                    info4.Semester = t.Semester;
                    info4.Year = t.Year;
                    var info6 = dbContext.CourseGrades.Where(u => u.CourseId == t.CourseId && u.TeacherId == t.TeacherId).ToList().FirstOrDefault();
                    info4.CourseGrade = info6.AvgScore;
                    list1.Add(info4);
                }
                s.Info = list1;
                list.Add(s);

            }

            return Ok(new
            {
                status = true,
                result = list,
                msg = "查找课程成功"
            });
        }

        //查找帖子，包含关键字即可
        [HttpGet]
        public ActionResult<string> SearchPost(string keywords)
        {
            var info = dbContext.Posts.Where(u => u.Title.Contains(keywords)).ToList();

            if (info.Count == 0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找帖子失败,相关帖子不存在"
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

    }
}
