<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> tmp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("comment", Schema = "tjspace")]

    public class Comment
    {

        //评论id
        [Key]
        [JsonProperty("commentid")]
        [Required]
<<<<<<< HEAD
        [Column("comment_id", TypeName = "int(11)")]
        public int CommentId { get; set; }
=======
        [Column("comment_id")]
        [StringLength(maximumLength: 50)]
        public string CommentId { get; set; }
>>>>>>> tmp

        //内容
        [JsonProperty("content")]
        [Required]
        [Column("content")]
<<<<<<< HEAD
        [StringLength(maximumLength: 20)]
        public string Content { get; set; }

        //发布时间
        [JsonProperty("date")]
        [Required]
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
=======
        [StringLength(maximumLength: 200)]
        public string Content { get; set; }

        //教学水平
        [JsonProperty("teaching")]
        [Column("teaching")]
        [StringLength(maximumLength: 200)]
        public string Teaching { get; set; }

        //给分情况
        [JsonProperty("grade")]
        [Column("grade")]
        [StringLength(maximumLength: 200)]
        public string Grade { get; set; }

        //教学水平
        [JsonProperty("homework")]
        [Column("homework")]
        [StringLength(maximumLength: 200)]
        public string Homework { get; set; }

        //有无期中考试
        [JsonProperty("midterm")]
        [Required]
        [Column("midterm", TypeName = "int(11)")]
        public int Midterm { get; set; }

        //有无期末考试
        [JsonProperty("final")]
        [Required]
        [Column("final", TypeName = "int(11)")]
        public int Final { get; set; }

        //有无小测
        [JsonProperty("quiz")]
        [Required]
        [Column("quiz", TypeName = "int(11)")]
        public int Quiz { get; set; }

        //有无作业
        [JsonProperty("assignment")]
        [Required]
        [Column("assignment", TypeName = "int(11)")]
        public int Assignment { get; set; }

        //有无论文
        [JsonProperty("essay")]
        [Required]
        [Column("essay", TypeName = "int(11)")]
        public int Essay { get; set; }

        //有无项目
        [JsonProperty("project")]
        [Required]
        [Column("project", TypeName = "int(11)")]
        public int Project { get; set; }

        //有无点名
        [JsonProperty("attendence")]
        [Required]
        [Column("attendence", TypeName = "int(11)")]
        public int Attendence { get; set; }

        //有无阅读材料
        [JsonProperty("reading")]
        [Required]
        [Column("reading", TypeName = "int(11)")]
        public int Reading { get; set; }

        //有无点名
        [JsonProperty("presentation")]
        [Required]
        [Column("presentation", TypeName = "int(11)")]
        public int Presentation { get; set; }
>>>>>>> tmp

        //课程总体评分
        [JsonProperty("overall")]
        [Required]
        [Column("overall", TypeName = "int(11)")]
        public int Overrall { get; set; }

        //对相关教师的评分
        [JsonProperty("instructor")]
        [Required]
        [Column("instructor", TypeName = "int(11)")]
        public int Instructor { get; set; }

<<<<<<< HEAD
        //课程的难易程度量化评分
        [JsonProperty("difficulty")]
        [Required]
        [Column("difficulty", TypeName = "int(11)")]
        public int Difficulty { get; set; }
=======
        //课程的给分情况的评分
        [JsonProperty("grading")]
        [Required]
        [Column("grading", TypeName = "int(11)")]
        public int Grading { get; set; }
>>>>>>> tmp

        //工作量量化评分
        [JsonProperty("workload")]
        [Required]
        [Column("workload", TypeName = "int(11)")]
        public int Workload { get; set; }

<<<<<<< HEAD
        //点赞数
        [JsonProperty("usefulnum")]
        [Column("useful",TypeName ="int(11)")]
=======
        //发布时间
        [JsonProperty("date")]
        [Required]
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }

        //点赞数
        [JsonProperty("usefulnum")]
        [Column("useful_num",TypeName ="int(11)")]
>>>>>>> tmp
        public int UsefulNum { get; set; }

        //点踩数
        [JsonProperty("uselessnum")]
<<<<<<< HEAD
        [Column("useless", TypeName = "int(11)")]
=======
        [Column("useless_num", TypeName = "int(11)")]
>>>>>>> tmp
        public int UselessNum { get; set; }

        //用户id
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
<<<<<<< HEAD
        [StringLength(maximumLength: 20)]
=======
        [StringLength(maximumLength: 50)]
>>>>>>> tmp
        public string UserId { get; set; }

        //是否匿名
        [JsonProperty("anomymous")]
        [Required]
        [Column("anonymous",TypeName ="int(11)")]
        public int Anonymous { get; set; }

        //课程编号
        [JsonProperty("courseid")]
        [Required]
        [Column("course_id")]
<<<<<<< HEAD
        [StringLength(maximumLength:20)]
=======
        [StringLength(maximumLength:50)]
>>>>>>> tmp
        public string CourseId { get; set; }

        //授课老师编号
        [JsonProperty("teacherid")]
        [Required]
        [Column("teacher_id")]
<<<<<<< HEAD
        [StringLength(maximumLength:10)]
=======
        [StringLength(maximumLength:50)]
>>>>>>> tmp
        public string TeacherId { get; set; }





    }
}
