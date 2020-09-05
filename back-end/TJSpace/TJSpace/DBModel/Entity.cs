using System;
namespace TJSpace.DBModel
{
    public class SearchCourseReturn
    {
        public string TeacherName { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
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
    }

    public class ShowCommentReturn
    {
        public string nickname { get; set; }
        public int grade { get; set; }
        public string major { get; set; }
    }
}
