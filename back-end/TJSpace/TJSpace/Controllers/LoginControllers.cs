using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
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
        public async Task<ActionResult<string>> LoginAsync(string email, string password)
        {
            var info = dbContext.Accounts.Where(n => n.Email.Equals(email) && n.Password.Equals(password)&& n.Type==0).ToList().FirstOrDefault();
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
                var tokenClient = new TokenClient("http://175.24.115.240:5000/connect/token", "client2", "secret");
                var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(email, password);
                if (tokenResponse.IsError)
                {
                    return Ok(new
                    {
                        status = false,
                        msg = "验证失败",
                        data = ""
                    });
                }
                return Ok(new
                {
                    status = true,
                    msg = "登录成功",
                    data = tokenResponse.AccessToken
                });
            }

        }
    }
}
