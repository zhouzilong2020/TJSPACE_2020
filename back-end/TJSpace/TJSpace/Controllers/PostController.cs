using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
        public ActionResult<string> post(string title, string content, string userId)
        {
            Post p = new Post();

            p.PostId = Guid.NewGuid().ToString();
            p.Title = title;
            p.Content = content;
            p.UserId = userId;
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
        public ActionResult<string> reply(string content, string userId, string postId, int floor, int type)
        {
            Reply p = new Reply();

            p.PostId = postId;

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
            p.Content = content;
            p.UserId = userId;
            p.Date = DateTime.Now;

            if (type == 0)//正常楼层
            {
                if(post.Floor + 1 != floor)
                {
                    return Ok(new
                    {
                        status = false,
                        msg = "回帖失败，回帖楼层错误"
                    });
                }
                post.Floor++;
            }
            p.Floor = floor;
            p.Type = type;

            dbContext.Replies.Add(p);
            
            if ((type==0 && dbContext.SaveChanges()==2)||(type==1&&dbContext.SaveChanges()==1))
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

        //对帖子进行评价
        [HttpPut]
        public ActionResult<string> evaluate(string postID,string userID, int type)
        {
            var post = dbContext.Posts.Where(u => u.PostId == postID).ToList().FirstOrDefault();
            if (post == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败,帖子不存在"
                });
            }
            
            if (type == 1)
            {
                post.UsefulNum += 1;
            }
            else if (type == 0)
            {
                post.UselessNum += 1;
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败"
                });
            }

            Mark m = new Mark();
            m.UserId = userID;
            m.PostId = postID;
            m.Type = type;
            m.Date= DateTime.Now;

            dbContext.marks.Add(m);

            if (dbContext.SaveChanges() == 2)
            {
                return Ok(new
                {
                    status = true,
                    msg = "评价成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败"
                });
            }
        }

    }
}
