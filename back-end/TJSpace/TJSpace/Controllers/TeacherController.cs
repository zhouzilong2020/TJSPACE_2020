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
        [HttpPut]
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
        [HttpDelete]
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
    }
}
