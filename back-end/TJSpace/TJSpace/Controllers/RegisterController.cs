using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using TJSpace.DBModel;
using TJSpace.Tools;

namespace TJSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public RegisterController(DataDBContext context)
        {
            dbContext = context;
        }
    
        //注册（包含对密码、昵称格式的检验）
        //POST 
        [HttpPost]
        [Route("register")]
        public ActionResult<string> Register(string email, string password, string nickname)
        {
            var uuid = Guid.NewGuid().ToString();
            var info = dbContext.Users.Where(n => n.NickName.Equals(nickname)).ToList().FirstOrDefault();
            if (info != null)
                return Ok(new
                {
                    status = false,
                    msg = "昵称重复"
                });

            dbContext.Users.Add(new DBModel.User { UserId = uuid,NickName = nickname});
            dbContext.SaveChanges();

            dbContext.Accounts.Add(new DBModel.Account { UserId = uuid, Email = email, Password = password, State = 1, Type = 0 });

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    userId=uuid,
                    msg = "注册成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "注册失败"
                });
            }
            
        }

        //发送验证邮件
        //GET 
        [HttpGet]
        [Route("email")]
        public ActionResult<string> SendEmail(string email,string code)
        {
            if (!Check.CheckEmail(email))
            {
                return Ok(new
                {
                    status = false,
                    msg = "邮箱不合法"
                });
            }

            string smtp = "smtp.qq.com";//qq的SMTP服务器地址
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtp; //指定SMTP服务器
            _smtpClient.Port = 587;
            _smtpClient.Credentials = new System.Net.NetworkCredential("1227678132@qq.com", "mpyyzwkycczghhgc");//设置用于验证发件人身份的凭据
            MailMessage _mailMessage = new MailMessage();

            //发件人，发件人名 
            _mailMessage.From = new MailAddress("1227678132@qq.com", "TJSpace");

            //收件人 
            _mailMessage.To.Add(email);

            _mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;//标题编码
             _mailMessage.Subject = "TJSpace验证邮件";//邮件主题
            _mailMessage.Body = "验证码" + code + "用于TJSpace验证" + "，请勿向任何人提供验证码！";//邮件内容
            _mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级   
            try
            {
                _smtpClient.Send(_mailMessage);

                return Ok(new
                {
                    status = true,
                    msg = "验证邮件发送成功"
                });
            }
            catch(Exception e)
            {
                //throw new Exception(e.ToString());
                return Ok(new
                {
                    status = false,
                    msg1 = e.ToString(),
                    msg2 = "验证邮件发送失败"
                }); 
                throw;
            }


        }

        //检查验证码
        //POST 
        [HttpPost]
        [Route("verify")]
        public ActionResult<string> Verify(string VerificationCode,string code)
        {
            if(VerificationCode.Equals(code))
            {
                return Ok(new
                {
                    status = true,
                    msg = "验证成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "验证失败"
                });
            }
        }

    }
}
