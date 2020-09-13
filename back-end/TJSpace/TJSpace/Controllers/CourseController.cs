using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TJSpace.DBModel;

namespace TJSpace.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public CourseController(DataDBContext context)
        {
            dbContext = context;
        }

        //添加课程信息
        [HttpPost]
        public ActionResult<string> AddCourse(Course course)
        {
            var c = dbContext.CourseCodes.Where(u => u.CourseId == course.CourseId).ToList().FirstOrDefault();
            if(c==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "添加课程失败,课程不存在"
                });
            }

            dbContext.Courses.Add(course);

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "添加课程成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "添加课程失败"
                });
            }
        }

        //修改课程信息
        [HttpPost]
        public ActionResult<string> ModifyCourse(Course course)
        {
            var temp = dbContext.Courses.Where(u => (u.CourseId == course.CourseId&&u.DeptName==course.DeptName)).ToList().FirstOrDefault();
            if (temp == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "修改课程信息失败，该课程不存在"
                });
            }

            temp.Credits = course.Credits;
            temp.DeptName = course.DeptName;
            temp.Intro = course.Intro;

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "修改课程信息成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "修改课程信息失败"
                });
            }
        }

        //删除课程信息
        [HttpPost]
        public ActionResult<string> DeleteCourse (string courseId)
        {
            var temp = dbContext.Courses.Where(u => u.CourseId == courseId).ToList().FirstOrDefault();
            if (temp == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "删除课程失败,该课程不存在"
                });
            }

            dbContext.Courses.Remove(temp);

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "删除课程成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "删除课程失败"
                });
            }
        }

        //收藏课程
        [HttpPost]
        public ActionResult<string> CollectCourse(string userId, string courseId,string teacherId)
        {
            var course = dbContext.Teaches.Where(u => (u.CourseId == courseId&&u.TeacherId==teacherId)).FirstOrDefault();
            if (course == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "收藏课程失败，课程不存在。"
                });
            }

            var user = dbContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "收藏课程失败，用户不存在。"
                });
            }

            CourseCollect cc = new CourseCollect();

            cc.UserId = userId;
            cc.CourseId = courseId;
            cc.TeacherId = teacherId;

            dbContext.CourseCollect.Add(cc);

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "收藏课程成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "收藏课程失败"
                });
            }
        }

        //删除收藏课程
        [HttpPost]
        public ActionResult<string> CancelCollectCourse(string userId, string courseId,string teacherId)
        {
            var cc = dbContext.CourseCollect.Where(u => (u.UserId == userId && u.CourseId == courseId&&u.TeacherId==teacherId)).FirstOrDefault();
            if(cc==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "取消收藏课程失败"
                });
            }

            dbContext.CourseCollect.Remove(cc);

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "取消收藏课程成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "取消收藏课程失败"
                });
            }
        }
    }
}
