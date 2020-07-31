using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("course_code", Schema = "tjspace")]

    public class CourseCode
    {
        //课程编号
        [JsonProperty("courseid")]
        [Required]
        [Column("course_id")]
        [StringLength(maximumLength: 10)]
        public string CourseId { get; set; }

        //课程名
        [JsonProperty("title")]
        [Required]
        [Column("title")]
        [StringLength(maximumLength: 16)]
        public string Title { get; set; }


    }
}
