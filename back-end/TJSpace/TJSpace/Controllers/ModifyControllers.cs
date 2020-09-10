using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TJSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModifyController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public ModifyController(DataDBContext context)
        {
            dbContext = context;
        }

        //修改个人信息
        //PUT
        [HttpPut]
        [Route("Info")]
        public ActionResult<string> ModifyInfo(string userId, string nickname, int gender, string phoneNumber, string majorId, int year, int degree)
        {
            var info = dbContext.Users.Where(n => n.UserId.Equals(userId)).ToList().FirstOrDefault();
            info.NickName = nickname;
            info.Gender = gender;
            info.PhoneNumber = phoneNumber;
            info.MajorId = majorId;
            dbContext.SaveChanges();
            return Ok(new
            {
                status = true,
                msg = "修改信息成功"
            });
        }
    }
}