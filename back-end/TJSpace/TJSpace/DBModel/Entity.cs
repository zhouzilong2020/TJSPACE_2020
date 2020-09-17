using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace TJSpace.DBModel
{
    public class SearchCourseReturn
    {
        public string CourseName { get; set; }
        public int CourseCredit { get; set; }
        public string CourseId { get; set; }
        public string CourseIntro { get; set; }
        public string TeacherName { get; set; }
        public string TeacherId { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public double CourseGrade { get; set; }
        public string CourseImageUrl { get; set; }
    }

    public class SearchPostReturn
    {
        public string PostId { get; set; }//帖子id
        public string Title { get; set; }//帖子名称
        public DateTime Date { get; set; }//帖子标题
        public string Name { get; set; }//发帖人
    }

    public class ShowPostReturn
    {
        public string ReplyId { get; set; }
        public int floor { get; set; }
        public int type { get; set; }
        public string name { get; set; }
    }

    public class ShowCommentReturn
    {
        public string nickname { get; set; }
        public int grade { get; set; }
        public string major { get; set; }
    }

    public class GetPostReturn
    {
        public string nickname { get; set; }
        public DateTime date { get; set; }
        public int numOfReply { get; set; }
        public DateTime LatestReply { get; set; }
        public int usefulNum { get; set; }
        public int uselessNum { get; set; }
        public string title { get; set; }//帖子标题
        public string content { get; set; }//帖子内容
        public string postId { get; set; }//帖子id
        public int canThumb { get; set; }//可以点赞，0不可，1可
        public int canStep { get; set; }//可以点踩，0不可，1可
    }

    public class getCollectedCourseReturn
    {
        public string CourseName { get; set; }
        public string CourseId { get; set; }
        public string DeptName { get; set; }
        public int Credit { get; set; }
        public string TeacherName { get; set; }
        public string TeacherId { get; set; }
    }

    public class section
    {
        public int Year { get; set; }
        public int Semester { get; set; }
    }
}
