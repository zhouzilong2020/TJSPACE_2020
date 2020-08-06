using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TJSpace.DBModel;

namespace TJSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("teacher")]
        public ActionResult<string> SearchTeacher(string name)
        {
            List<Teacher> list= dbContext.Teachers.Where(n => n.Name.Equals(name)).ToList();
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
        [Route("teaches")]
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

            var info2= dbContext.Teaches.Where(n => n.TeacherId.Equals(teacherid)).ToList().FirstOrDefault();
            if (info2 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "该名老师未开课"
                });
            }
            string courseid = info2.CourseId;

            var info3= dbContext.CourseCodes.Where(n => n.CourseId.Equals(courseid)).ToList().FirstOrDefault();

            return Ok(new
            {
                status = true,
                data_1 = courseInfo,
                data_2 = info3.Title,
                msg = "检索成功"
            });
        }
    }
}
