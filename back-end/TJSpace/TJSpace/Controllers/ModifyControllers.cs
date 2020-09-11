using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TJSpace.DBModel;
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
        [HttpPost]
        [Route("Info")]
        public ActionResult<string> ModifyInfo(User user)
        {
            var info = dbContext.Users.Where(n => n.UserId.Equals(user.UserId)).ToList().FirstOrDefault();
            info.NickName = user.NickName;
            info.Gender = user.Gender;
            info.PhoneNumber = user.PhoneNumber;
            info.MajorId = user.MajorId;
            dbContext.SaveChanges();
            return Ok(new
            {
                status = true,
                msg = "修改信息成功"
            });
        }
    }
}