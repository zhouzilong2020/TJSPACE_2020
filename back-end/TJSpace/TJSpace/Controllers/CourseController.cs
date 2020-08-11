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

        //添加课程
        [HttpPost]
        public ActionResult<string> AddCourse(Course course)
        {
            course.CourseId = Guid.NewGuid().ToString();
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
        [HttpPut]
        public ActionResult<string> ModifyCourse(Course course)
        {
            var temp = dbContext.Courses.Where(u => u.CourseId == course.CourseId).ToList().FirstOrDefault();
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

        //删除课程
        [HttpDelete]
        public ActionResult<string> DeleteCourse ([FromBody]string CourseId)
        {
            var temp = dbContext.Courses.Where(u => u.CourseId == CourseId).ToList().FirstOrDefault();
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
    }
}
