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
        public ActionResult<string> ShowUser(string userId)
        {
            List<User> list = dbContext.Users.Where(n => n.UserId.Equals(userId)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }

        //查看课程评价
        //GET
        [HttpGet]
        [Route("comment")]
        public ActionResult<string> showComment(string courseId)
        {
            List<Comment> list = dbContext.Comments.Where(n => n.CourseId.Equals(courseId)).ToList();
            List<ShowCommentReturn> info = new List<ShowCommentReturn>();
            foreach(var r in list)
            {
                //var x= dbContext.Comments.Where(n => n.CourseId.Equals(courseID)).ToList().FirstOrDefault();
                var user = dbContext.Users.Where(n => n.UserId.Equals(r.UserId)).ToList().FirstOrDefault();
                var dept= dbContext.Majors.Where(n => n.MajorId.Equals(user.MajorId)).ToList().FirstOrDefault();
                info.Add(new ShowCommentReturn { grade = user.Year, major = dept.MajorName, nickname = user.NickName });

            }
            return Ok(new
            {
                status = true,
                data1 = list,
                data2 = info,
                msg = "查看数据成功"
            }); ;
        }

        //查看贴子
        //GET
        [HttpGet]
        [Route("post")]
        public ActionResult<string> showPost(string postId)
        {
            List<Post> list = dbContext.Posts.Where(n => n.PostId.Equals(postId)).ToList();
            var x = dbContext.Posts.Where(n => n.PostId.Equals(postId)).ToList().FirstOrDefault();
            var y = dbContext.Users.Where(n => n.UserId.Equals(x.UserId)).ToList().FirstOrDefault();
            var info = dbContext.Replies.Where(n => n.PostId.Equals(postId)).ToList();
            if (info == null)
            {
                return Ok(new
                {
                    status = true,
                    data = list,
                    nickname=y.NickName,
                    msg = "查看数据成功,该帖不存在回复"
                });
            }

            List<ShowPostReturn> replyid = new List<ShowPostReturn>();
            //foreach (var r in info)
            //{
                var replies = dbContext.Replies.Where(n => n.PostId.Equals(postId)).ToList();
                foreach (var reply in replies)
                {
                    var z = dbContext.Users.Where(n => n.UserId.Equals(reply.UserId)).ToList().FirstOrDefault();
                    replyid.Add(new ShowPostReturn { ReplyId = reply.ReplyId, type = reply.Type, floor = reply.Floor,
                    name=z.NickName});
                }
            //}

            //var x = dbContext.Marks.Where(n => n.UserId.Equals(userId)).ToList().FirstOrDefault();
            //if (x == null)
            //{
            //    return Ok(new
            //    {
            //        status = true,
            //        data1 = list,
            //        data2 = replyid,
            //        data3 = 0,
            //        msg = "查看数据成功"
            //    });
            //}

            //int attitude = x.Type;
            return Ok(new
            {
                status = true,
                data1 = list,
                data2 = y.NickName,
                data3=replyid,
                //data3 = attitude,
                msg = "查看数据成功"
            });
        }

        //查看贴子回复
        //GET
        [HttpGet]
        [Route("reply")]
        public ActionResult<string> showReply(string str)
        {
            string[] sArray = str.Split(',');
            List<List<Reply>> info = new List<List<Reply>>();
            foreach (string replyId in sArray) 
            {
                List<Reply> list = dbContext.Replies.Where(n => n.ReplyId.Equals(replyId)).ToList();
                info.Add(list);
            }
            return Ok(new
            {
                status = true,
                data = info,
                msg = "查看数据成功"
            });
        }

        //查看历史评价
        //GET
        [HttpGet]
        [Route("personalcomment")]
        public ActionResult<string> showPersonalComment(string userId)
        {
            List<Comment> list = dbContext.Comments.Where(n => n.UserId.Equals(userId)).ToList();
            List<showPersonalCommentReturn> list1 = new List<showPersonalCommentReturn>();

            foreach(var v in list)
            {
                showPersonalCommentReturn s = new showPersonalCommentReturn();
                var info = dbContext.CourseCodes.Where(u => u.CourseId == v.CourseId).ToList().FirstOrDefault();
                s.CourseName = info.Title;
                s.CommentId = v.CommentId;
                s.CourseId = info.CourseId;
                s.UsefulNum = v.UsefulNum;
                s.UselessNum = v.UselessNum;
                s.Date = v.Date;
                s.Overall = v.Overrall;
                
                list1.Add(s);
            }
            
            return Ok(new
            {
                status = true,
                data = list1,
                msg = "查看数据成功"
            });
        }

        //查看历史回复
        //GET
        [HttpGet]
        [Route("personalreply")]
        public ActionResult<string> showPersonalReply(string userId)
        {
            List<Reply> list = dbContext.Replies.Where(n => n.UserId.Equals(userId)).ToList();
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
        public ActionResult<string> showPersonalPost(string userId)
        {
            List<Post> list = dbContext.Posts.Where(n => n.UserId.Equals(userId)).ToList();
            return Ok(new
            {
                status = true,
                data = list,
                msg = "查看数据成功"
            });
        }

        //获取主页显示的帖子
        [HttpGet]
        [Route("getPosts")]
        public ActionResult<string> getPost(int orderType,int startPosition,string userId)
        {
            List<Post> info = dbContext.Posts.ToList();
            List<GetPostReturn> info2 = new List<GetPostReturn>();
            switch(orderType)
            {
                case 0:
                    info = info.OrderByDescending(u => u.LatestReply).ThenBy(u => u.Title).ToList();
                    break;
                case 1:
                    info = info.OrderBy(u => u.LatestReply).ThenBy(u => u.Title).ToList();
                    break;
                case 2:
                    info = info.OrderBy(u => u.Date).ThenBy(u => u.Title).ToList();
                    break;
                case 3:
                    info = info.OrderByDescending(u => u.Date).ThenBy(u => u.Title).ToList();
                    break;

            }
            

            int count = 0;
            int cnt = 0;
            
            foreach(var k in info)
            {
                if(++cnt<=startPosition)
                {
                    continue;
                }
                GetPostReturn t = new GetPostReturn();
                var user = dbContext.Marks.Where(u => (u.UserId == userId && u.PostId==k.PostId)).FirstOrDefault();
                t.nickname = dbContext.Users.Where(u => u.UserId == k.UserId).FirstOrDefault().NickName;
                
                t.date = k.Date;
                t.numOfReply = k.Floor;
                t.LatestReply = k.LatestReply;
                t.usefulNum = k.UsefulNum;
                t.uselessNum = k.UselessNum;
                t.title = k.Title;
                t.content = k.Content;
                t.postId = k.PostId;
                t.canThumb = 1;
                t.canStep = 1;

                if(user!=null)
                {
                    if (user.Type == 1)//已经赞过不能赞
                    {
                        t.canThumb = 0;

                    }
                    else if(user.Type==0)
                    {
                        t.canStep = 0;
                    }
                }

                info2.Add(t);

                if(++count>=12)//一页只能返回12个
                {
                    break;
                }
            }
            if(info2!=null)
            {
                return Ok(new
                {
                    status = true,
                    posts = info2,
                    msg = "查看帖子成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "查看帖子失败"
                });
            }
        }

        //显示收藏课程
        [HttpGet]
        [Route("getCollectedCourse")]
        public ActionResult<string> getCollectedCourse(string userId)
        {
            var info1 = dbContext.CourseCollect.Where(u => (u.UserId == userId)).ToList();
            List<getCollectedCourseReturn> info = new List<getCollectedCourseReturn>();

            if (info1.Count()==0)
            {
                return Ok(new
                {
                    status = false,
                    msg = "该用户没有收藏任何课程"
                });
            }

            foreach (var k in info1)
            {
                getCollectedCourseReturn temp = new getCollectedCourseReturn();
                temp.CourseName = dbContext.CourseCodes.Where(u => u.CourseId == k.CourseId).FirstOrDefault().Title;
                var course = dbContext.Courses.Where(u => u.CourseId == k.CourseId).FirstOrDefault();
                temp.Credit = course.Credits;
                temp.DeptName = course.DeptName;
                temp.CourseId = k.CourseId;
                temp.TeacherId = k.TeacherId;
                temp.TeacherName = dbContext.Teachers.Where(u => u.TeacherId == k.TeacherId).FirstOrDefault().Name;
                info.Add(temp);
            }

            if (info != null)
            {
                return Ok(new
                {
                    status = true,
                    collectedcourse = info,
                    msg = "查看用户收藏课程成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "查看用户收藏课程失败"
                });
            }
        }
    }
}

