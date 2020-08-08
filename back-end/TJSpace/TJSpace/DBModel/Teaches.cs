using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("teaches", Schema = "tjspace")]

    public class Teaches
    {
        //教师编号
        [Key]
        [JsonProperty("teacherid")]
        [Required]
        [Column("teacher_id")]
        [StringLength(maximumLength: 50)]
        public string TeacherId { get; set; }

        //课程编号
        [Key]
        [JsonProperty("courseid")]
        [Required]
        [Column("course_id")]
        [StringLength(maximumLength: 50)]
        public string CourseId { get; set; }

        //开课学期
        [Key]
        [JsonProperty("semester")]
        [Required]
        [Column("semester", TypeName = "int(11)")]
        public int Semester { get; set; }

        //开课年份
        [JsonProperty("year")]
        [Required]
        [Column("year", TypeName = "int(11)")]
        public int Year { get; set; }

    }
}
