using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TJSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public LoginController(DataDBContext context)
        {
            dbContext = context;
        }

        //用户登录
        //GET
        [HttpGet]
        [Route("login")]
        public ActionResult<string> Login(string email,string password)
        {
            var info=dbContext.Accounts.Where(n=>n.Email.Equals(email)&&n.Password.Equals(password)).ToList().FirstOrDefault();
            if (info == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "登录失败"
                });
            }
            else
            {
                return Ok(new
                {
                    status = true,
                    msg = "登录成功"
                });
            }

        }
    }
}
