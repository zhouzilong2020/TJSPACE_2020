using System;
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
        [Column("comment_id", TypeName = "int(11)")]
        public int CommentId { get; set; }

        //内容
        [JsonProperty("content")]
        [Required]
        [Column("content")]
        [StringLength(maximumLength: 20)]
        public string Content { get; set; }

        //发布时间
        [JsonProperty("date")]
        [Required]
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }

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

        //课程的难易程度量化评分
        [JsonProperty("difficulty")]
        [Required]
        [Column("difficulty", TypeName = "int(11)")]
        public int Difficulty { get; set; }

        //工作量量化评分
        [JsonProperty("workload")]
        [Required]
        [Column("workload", TypeName = "int(11)")]
        public int Workload { get; set; }

        //点赞数
        [JsonProperty("usefulnum")]
        [Column("useful",TypeName ="int(11)")]
        public int UsefulNum { get; set; }

        //点踩数
        [JsonProperty("uselessnum")]
        [Column("useless", TypeName = "int(11)")]
        public int UselessNum { get; set; }

        //用户id
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
        [StringLength(maximumLength: 20)]
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
        [StringLength(maximumLength:20)]
        public string CourseId { get; set; }

        //授课老师编号
        [JsonProperty("teacherid")]
        [Required]
        [Column("teacher_id")]
        [StringLength(maximumLength:10)]
        public string TeacherId { get; set; }





    }
}
