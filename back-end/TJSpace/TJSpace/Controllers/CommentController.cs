using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
using TJSpace.DBModel;

namespace TJSpace.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public CommentController(DataDBContext context)
        {
            dbContext = context;
        }

        //发布对课程评价
        [HttpPost]
        public ActionResult<string>PostComment(Comment comment)
        {
            //检查教师id是否存在
            List<Teacher> list1 = dbContext.Teachers.Where(u => u.TeacherId == comment.TeacherId).ToList();
            if(list1.Count()==0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，评价教师不存在！"
                });
            }

            //检查课程id是否存在
            List<Course> list2 = dbContext.Courses.Where(u => u.CourseId == comment.CourseId).ToList();
            if (list2.Count() == 0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，评价课程不存在！"
                });
            }

            //检查用户id是否存在
            List<User> list3 = dbContext.Users.Where(u => u.UserId == comment.UserId).ToList();
            if (list2.Count() == 0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，用户不存在！"
                });
            }

            comment.CommentId = Guid.NewGuid().ToString();
            comment.Date = DateTime.Now;
            comment.UsefulNum = 0;
            comment.UselessNum = 0;
            
            dbContext.Comments.Add(comment);

            if(dbContext.SaveChanges()==1)
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

        //对评价进行评价
        [HttpPost]
        public ActionResult<string> EvaluateComment(string commentId,string userId,int type)
        {
            var comment = dbContext.Comments.Where(u => u.CommentId == commentId).ToList().FirstOrDefault();
            if(comment==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，评价不存在"
                });
            }
            if(type==1)
            {
                comment.UsefulNum++;
            }
            else
            {
                comment.UselessNum++;
            }
            Credibility cre = new Credibility();

            cre.CommentId = commentId;
            cre.UserId = userId;
            cre.Type = type;
            cre.Date = DateTime.Now;

            dbContext.Credibilities.Add(cre);           
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

        //管理员删除评价
        [HttpDelete]
        public ActionResult<string> DeleteComment(string commentId)
        {
            var comment = dbContext.Comments.Where(u => u.CommentId == commentId).ToList().FirstOrDefault();
            if(comment==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "删除失败,评论不存在"
                });
            }
            dbContext.Comments.Remove(comment);
            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "删除成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "删除失败"
                });
            }
        }
    }
}
