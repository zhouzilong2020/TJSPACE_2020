using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("takes", Schema = "tjspace")]

    public class Takes
    {
        //用户编号
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
        [StringLength(maximumLength: 20)]
        public string UserId { get; set; }

        //课程编号
        [JsonProperty("courseid")]
        [Required]
        [Column("course_id")]
        [StringLength(maximumLength: 10)]
        public string CourseId { get; set; }

        //开课学期
        [JsonProperty("semester")]
        [Required]
        [Column("semester",TypeName ="int(11)")]
        public string Semester { get; set; }

        //开课年份
        [JsonProperty("year")]
        [Required]
        [Column("year", TypeName = "int(11)")]
        public string Year { get; set; }

        //对课程给分情况的评价
        [JsonProperty("gpa")]
        [Required]
        [Column("gpa", TypeName = "int(11)")]
        public string Gpa { get; set; }
    }
}
