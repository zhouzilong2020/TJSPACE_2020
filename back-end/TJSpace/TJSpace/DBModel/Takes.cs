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
        [Key]
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
<<<<<<< HEAD
        [StringLength(maximumLength: 20)]
=======
        [StringLength(maximumLength: 50)]
>>>>>>> tmp
        public string UserId { get; set; }

        //课程编号
        [Key]
        [JsonProperty("courseid")]
        [Required]
        [Column("course_id")]
<<<<<<< HEAD
        [StringLength(maximumLength: 10)]
=======
        [StringLength(maximumLength: 50)]
>>>>>>> tmp
        public string CourseId { get; set; }

        //开课学期
        [Key]
        [JsonProperty("semester")]
        [Required]
        [Column("semester",TypeName ="int(11)")]
        public int Semester { get; set; }

        //开课年份
        [Key]
        [JsonProperty("year")]
        [Required]
        [Column("year", TypeName = "int(11)")]
        public int Year { get; set; }

        //对课程给分情况的评价
        [JsonProperty("gpa")]
        [Required]
        [Column("gpa", TypeName = "int(11)")]
        public int Gpa { get; set; }
    }
}
