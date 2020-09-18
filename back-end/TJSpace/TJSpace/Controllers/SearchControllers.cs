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
using System.Collections;

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
            if (info1.Count() == 0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找课程失败,无相关课程"
                });
            }

            foreach (var r in info1)
            {
                var id = r.CourseId;
                var info2 = dbContext.Courses.Where(u => u.CourseId == r.CourseId).ToList().FirstOrDefault();
                if (info2 == null)
                {
                    continue;
                }

                var info3 = dbContext.Teaches.Where(u => u.CourseId == r.CourseId).ToList();
                List<string> copyList = new List<string>();
                Hashtable hash = new Hashtable();

                foreach (var temp in info3)
                {
                    if (!hash.ContainsKey(temp.CourseId))
                    {
                        hash.Add(temp.CourseId, temp.CourseId);
                        copyList.Add(temp.CourseId);
                    }
                }
                foreach (var t in copyList)
                {
                    SearchCourseReturn s = new SearchCourseReturn();
                    s.CourseName = r.Title;
                    s.CourseCredit = info2.Credits;
                    s.CourseId = r.CourseId;
                    s.CourseIntro = info2.Intro;
                    var info7 = dbContext.Teaches.Where(u => u.CourseId == t).ToList().FirstOrDefault();
                    s.TeacherId = info7.TeacherId;
                    var info5 = dbContext.Teachers.Where(u => u.TeacherId == s.TeacherId).ToList().FirstOrDefault();
                    s.TeacherName = info5.Name;
                    var info6 = dbContext.CourseGrades.Where(u => u.CourseId == s.CourseId && u.TeacherId == s.TeacherId).ToList().FirstOrDefault();
                    s.CourseGrade = info6.AvgScore;
                    s.CourseImageUrl = r.CourseImageUrl;
                    list.Add(s);
                }
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

        //根据courseId搜索课程信息
        [HttpGet]
        public ActionResult<string> SearchCourseByCourseId(string courseId)
        {
            var info1 = dbContext.CourseCodes.Where(u => u.CourseId == courseId).ToList().FirstOrDefault();
            if(info1==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找课程失败，课程不存在"
                });
            }
            
            List<SearchCourseByCourseIdReturn> list = new List<SearchCourseByCourseIdReturn>();
            
            var info2 = dbContext.Teaches.Where(u => u.CourseId == courseId).ToList();
            List<string> copyList = new List<string>(); 
            Hashtable hash = new Hashtable();
            
            foreach (var temp in info2)
            {
                if(!hash.ContainsKey(temp.TeacherId))
                {
                    hash.Add(temp.TeacherId,temp.TeacherId);
                    copyList.Add(temp.TeacherId);
                }
            }

            foreach (var v in copyList)
            {
                SearchCourseByCourseIdReturn s = new SearchCourseByCourseIdReturn();
                List<section> sect = new List<section>();

                var info3 = dbContext.Courses.Where(u => u.CourseId == courseId).ToList().FirstOrDefault();
                var info4 = dbContext.Teachers.Where(u => u.TeacherId == v).ToList().FirstOrDefault();
                s.Department = info3.DeptName;
                s.TeacherName = info4.Name;
                s.TeacherId = v;
                var info5 = dbContext.Teaches.Where(u => u.TeacherId == v).ToList();
                foreach(var temp in info5)
                {
                    sect.Add(new section { Year = temp.Year, Semester = temp.Semester });
                    s.Section = sect;
                }
                
                list.Add(s);
            }

            return Ok(new
            {
                status = true,               
                title = info1.Title,
                courseId = info1.CourseId,
                url = info1.CourseImageUrl,
                teacher=list,
                msg = "查找课程成功"
            }) ;
        }

        //唯一确定一门课程
        [HttpGet]
        public ActionResult<string>SearchCourseUnique(string teacherId,string courseId)
        {
            var info1 = dbContext.Teaches.Where(u => u.TeacherId == teacherId && u.CourseId == courseId).ToList();
            if(info1==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "查找课程失败"
                });
            }

            var info2 = dbContext.Courses.Where(u => u.CourseId == courseId).ToList().FirstOrDefault();
            var info3 = dbContext.CourseCodes.Where(u => u.CourseId == courseId).ToList().FirstOrDefault();
            var info4 = dbContext.CourseGrades.Where(u => u.CourseId == courseId && u.TeacherId == teacherId).ToList().FirstOrDefault();
            var info5 = dbContext.Teachers.Where(u => u.TeacherId == teacherId).ToList().FirstOrDefault();

            List<section> list = new List<section>();

            foreach(var v in info1)
            {
                list.Add(new section { Semester = v.Semester, Year = v.Year });
            }

            return Ok(new
            {
                status = true,
                courseName=info3.Title,
                department=info2.DeptName,
                credit=info2.Credits,
                intro=info2.Intro,
                avgScore=info4.AvgScore,
                courseImageUrl=info3.CourseImageUrl,
                teacherName=info5.Name,
                section=list,
                msg = "查找课程成功"
            });
        }
    }
}
