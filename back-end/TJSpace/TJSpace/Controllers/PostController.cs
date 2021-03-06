﻿using System;
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
            p.LatestReply = DateTime.Now;

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
            post.LatestReply = DateTime.Now;

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
        [HttpPost]
        public ActionResult<string> evaluate(string postId,string userId, int type)
        {
            var evaluation = dbContext.Marks.Where(u => u.PostId == postId && u.UserId == userId).FirstOrDefault();
            if (evaluation != null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败,评价已经存在"
                });
            }
            var post = dbContext.Posts.Where(u => u.PostId == postId).ToList().FirstOrDefault();
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
            m.UserId = userId;
            m.PostId = postId;
            m.Type = type;
            m.Date= DateTime.Now;

            dbContext.Marks.Add(m);

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

        [HttpPost]
        public ActionResult<string> CancelEvaluation(string postId,string userId)
        {
            var evaluation = dbContext.Marks.Where(u => (u.UserId == userId && u.PostId == postId)).FirstOrDefault();
            if(evaluation==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "取消评价失败，评价不存在"
                });
            }

            var post = dbContext.Posts.Where(u => u.PostId == postId).FirstOrDefault();
            if(post==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "取消评价失败，评价不存在"
                });
            }

            if(evaluation.Type==1)
            {
                post.UsefulNum--;
            }
            else
            {
                post.UselessNum--;
            }

            dbContext.Marks.Remove(evaluation);

            if (dbContext.SaveChanges() == 2)
            {
                return Ok(new
                {
                    status = true,
                    msg = "取消评价成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "取消评价失败"
                });
            }
        }


        [HttpGet]
        public ActionResult<string> CanEvaluate(string postId,string userId)
        {
            var evaluation = dbContext.Marks.Where(u => (u.PostId == postId && u.UserId == userId)).FirstOrDefault();

            if (evaluation == null)
            {
                return Ok(new
                {
                    status = true,
                    canEvaluate = true,
                    msg = "查询成功，不存在评价，可以评价"
                });
            }
            else
            {
                return Ok(new
                {
                    status = true,
                    canEvaluate = false,
                    type = evaluation.Type,
                    msg = "查询成功，存在评价，不可以评价"
                });
            }
        }
    }
}
