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
    public class PostController : ControllerBase
    {
        private readonly DataDBContext dbContext;
        public PostController(DataDBContext context)
        {
            dbContext = context;
        }

        //发帖
        [HttpPost]
        public ActionResult<string> post(Post p)
        {
            p.PostId = Guid.NewGuid().ToString();
            p.Date = DateTime.Now;
            dbContext.Posts.Add(p);
            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "发帖成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "发帖失败"
                });
            }
        }

        //回帖
        [HttpPost]
        public ActionResult<string> reply(Reply p)
        {
            p.Date = DateTime.Now;
            var post = dbContext.Posts.Where(u => u.PostId == p.PostId).ToList().FirstOrDefault();
            if (post == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "回帖失败，帖子不存在"
                });
            }

            p.ReplyId = Guid.NewGuid().ToString();

            dbContext.Replies.Add(p);

            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "回帖成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "回帖失败"
                });
            }
        }

        //对帖子或回复进行评价，暂定，未加属性
        

    }
}
