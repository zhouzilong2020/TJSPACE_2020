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
    public class TeacherController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public TeacherController(DataDBContext context)
        {
            dbContext = context;
        }

        //添加教师
        [HttpPost]
        public ActionResult<string> AddTeacher(Teacher teacher)
        {
            teacher.TeacherId = Guid.NewGuid().ToString();
            dbContext.Teachers.Add(teacher);
            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "添加教师成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "添加教师失败"
                });
            }
        }

        //修改教师信息
        [HttpPost]
        public ActionResult<string> ModifyTeacher(Teacher teacher)
        {
            var temp = dbContext.Teachers.Where(u => u.TeacherId == teacher.TeacherId).ToList().FirstOrDefault();
            if (temp == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "修改教师信息失败，该教师不存在"
                });
            }
            temp.Name = teacher.Name;
            temp.DeptName = teacher.DeptName;
            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "修改教师信息成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "修改教师信息失败"
                });
            }
        }

        //删除教师
        [HttpPost]
        public ActionResult<string> DeleteTeacher(string teacherId)
        {
            var temp = dbContext.Teachers.Where(u => u.TeacherId == teacherId).ToList().FirstOrDefault();
            if (temp == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "删除教师失败,该教师不存在"
                });
            }
            dbContext.Teachers.Remove(temp);

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "删除教师成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "删除教师失败"
                });
            }
        }

        //建立授课关系
        [HttpPost]
        public ActionResult<string>CreateTeachingRelation(string teacherId,string courseId,int semester,int year)
        {
            if(dbContext.Teachers.Where(u=>u.TeacherId==teacherId).ToList().FirstOrDefault()==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "建立授课关系失败,教师不存在"
                });
            }

            if (dbContext.CourseCodes.Where(u => u.CourseId == courseId).ToList().FirstOrDefault() == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "建立授课关系失败,课程不存在"
                });
            }

            var data = dbContext.Teaches.Where(u => u.CourseId == courseId && u.TeacherId == teacherId && u.Semester == semester&&u.Year==year).ToList().FirstOrDefault();
            if(data!=null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "建立授课关系失败,该关系已存在"
                });
            }

            dbContext.Teaches.Add(new DBModel.Teaches { CourseId = courseId, TeacherId = teacherId, Semester = semester, Year = year });
            dbContext.CourseGrades.Add(new DBModel.CourseGrade { CourseId = courseId, TeacherId = teacherId, AvgScore = 0.0 });
            
            if(dbContext.SaveChanges()==2)
            {
                return Ok(new
                {
                    status = true,
                    msg = "建立授课关系成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "建立授课关系失败"
                });
            }
        }
    }
}
