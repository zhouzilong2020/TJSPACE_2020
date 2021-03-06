﻿using System;
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
        public ActionResult<string>PostComment(string content,string teaching,string grade,string homework
            ,int midterm,int final,int quiz,int assignment,int essay,int project,int attendance,int reading
            ,int presentation,int overall,int instructor,int grading,int workload,string userId,int anonymous
            ,string courseId,string teacherId)
        {
            //检查评价是否存在
            var data2 = dbContext.Comments.Where(u => u.UserId == userId && u.CourseId == courseId && u.TeacherId == teacherId).ToList().FirstOrDefault();
            if(data2!=null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，不能重复评价！"
                });
            }

            //检查教师id是否存在
            var list1 = dbContext.Teachers.Where(u => u.TeacherId == teacherId).FirstOrDefault();
            if(list1 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，评价教师不存在！"
                });
            }

            //检查课程id是否存在
            var list2 = dbContext.Courses.Where(u => u.CourseId == courseId).FirstOrDefault();
            if (list2 == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，评价课程不存在！"
                });
            }

            //检查用户id是否存在
            var list3 = dbContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (list3  == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，用户不存在！"
                });
            }

            var data1 = dbContext.CourseGrades.Where(u => u.CourseId == courseId && u.TeacherId == teacherId).ToList().FirstOrDefault();
            if(data1==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，课程关系不存在！"
                });
            }

            Comment comment = new Comment();

            comment.CommentId = Guid.NewGuid().ToString();
            comment.Content = content;
            comment.Teaching = teaching;
            comment.Grade = grade;
            comment.Homework = homework;
            comment.Midterm = midterm;
            comment.Final = final;
            comment.Quiz = quiz;
            comment.Assignment = assignment;
            comment.Essay = essay;
            comment.Project = project;
            comment.Attendance = attendance;
            comment.Reading = reading;
            comment.Presentation = presentation;
            comment.Overrall = overall;
            comment.Instructor = instructor;
            comment.Grading = grading;
            comment.Workload = workload;
            comment.Date = DateTime.Now;
            comment.UsefulNum = 0;
            comment.UselessNum = 0;
            comment.UserId = userId;
            comment.Anonymous = anonymous;
            comment.CourseId = courseId;
            comment.TeacherId = teacherId;

            if (data1.AvgScore==0)
            {
                data1.AvgScore = comment.Overrall*1.0;
            }
            else
            {
                data1.AvgScore = 1.0*(data1.AvgScore + comment.Overrall) / 2;
            }

            dbContext.Comments.Add(comment);

            if(dbContext.SaveChanges()==2)
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
            var t = dbContext.Credibilities.Where(u => u.UserId == userId && u.CommentId == commentId).FirstOrDefault();
            if(t!=null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "评价失败，已经存在评价"
                });
            }
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

        [HttpPost]
        public ActionResult<string> CancelEvaluation(string commentId ,string userId)
        {
            var evaluation = dbContext.Credibilities.Where(u => (u.CommentId == commentId && u.UserId == userId)).FirstOrDefault();
            if (evaluation == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "取消评价失败，评价不存在"
                });
            }
            var comment = dbContext.Comments.Where(u => u.CommentId == commentId).ToList().FirstOrDefault();
            if (comment == null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "取消评价失败，评价不存在"
                });
            }
            if (evaluation.Type == 1)
            {
                comment.UsefulNum--;
            }
            else
            {
                comment.UselessNum--;
            }
            
            dbContext.Credibilities.Remove(evaluation);
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

        //管理员删除评价
        [HttpPost]
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

            var data = dbContext.CourseGrades.Where(u => u.CourseId == comment.CourseId && u.TeacherId == comment.TeacherId).ToList().FirstOrDefault();

            data.AvgScore = data.AvgScore * 2 - comment.Overrall;
            dbContext.Comments.Remove(comment);

            if (dbContext.SaveChanges() == 2)
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

        //查询是否可以对评价进行评价
        [HttpGet]
        public ActionResult<string> CanEvaluate(string commentId,string userId)
        {
            var evaluation = dbContext.Credibilities.Where(u => (u.CommentId == commentId && u.UserId == userId)).FirstOrDefault();
            
            if(evaluation==null)
            {
                return Ok(new
                {
                    status = true,
                    canEvaluate=true,
                    msg = "可以评价"
                });
            }
            else
            {
                return Ok(new
                {
                    status = true,
                    canEvaluate=false,
                    type=evaluation.Type,
                    msg = "不可以评价"
                });
            }
        }

        //查询是否可以进行评价
        [HttpGet]
        public ActionResult<string> CanPostComment(string userId,string courseId,string teacherId)
        {
            var evaluation = dbContext.Comments.Where(u => u.UserId == userId && u.CourseId == courseId && u.TeacherId == teacherId).ToList().FirstOrDefault();
            
            if (evaluation == null)
            {
                return Ok(new
                {
                    status = true,
                    canPostComment = true,
                    msg = "可以评价"
                });
            }
            else
            {
                return Ok(new
                {
                    status = true,
                    canPostComment = false,
                    msg = "不可以评价"
                });
            }
        }
    }
}
