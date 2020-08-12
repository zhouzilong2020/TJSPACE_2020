using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TJSpace.DBModel;

namespace TJSpace.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShowController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public ShowController(DataDBContext context)
        {
            dbContext = context;
        }

        //查看用户信息
        //GET
        [HttpGet]
        [Route("user")]
        public ActionResult<string> ShowUser(string userID)
        {
            List<User> list = dbContext.Users.Where(n => n.UserId.Equals(userID)).ToList();
            return Ok(new
            {
                status = true,
                data=list,
                msg="查看数据成功"
            });
        }

        //查看课程评价
        //GET
        [HttpGet]
        [Route("comment")]
        public ActionResult<string> showComment(string courseID)
        {
            List<Comment> list = dbContext.Comments.Where(n => n.CourseId.Equals(courseID)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }

        //查看贴子
        //GET
        [HttpGet]
        [Route("post")]
        public ActionResult<string> showPost(string postid)
        {
            List<Post> list = dbContext.Posts.Where(n => n.PostId.Equals(postid)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }

        //查看贴子回复
        //GET
        [HttpGet]
        [Route("reply")]
        public ActionResult<string> showReply(string replyid)
        {
            List<Reply> list = dbContext.Replies.Where(n => n.ReplyId.Equals(replyid)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }

        //查看历史评价
        //GET
        [HttpGet]
        [Route("personalcomment")]
        public ActionResult<string> showPersonalComment(string userid)
        {
            List<Comment> list = dbContext.Comments.Where(n => n.UserId.Equals(userid)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }

        //查看历史回复
        //GET
        [HttpGet]
        [Route("personalreply")]
        public ActionResult<string> showPersonalReply(string userid)
        {
            List<Reply> list = dbContext.Replies.Where(n => n.UserId.Equals(userid)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }

        //查看历史发帖
        //GET
        [HttpGet]
        [Route("personalpost")]
        public ActionResult<string> showPersonalPost(string userid)
        {
            List<Post> list = dbContext.Posts.Where(n => n.UserId.Equals(userid)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }
    }
}

