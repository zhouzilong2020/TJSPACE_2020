using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("teacher", Schema = "tjspace")]

    public class Teacher
    {
        //教师编号
        [Key]
        [JsonProperty("teacherid")]
        [Required]
        [Column("teacher_id")]
        [StringLength(maximumLength: 16)]
        public string TeacherId { get; set; }

        //教师姓名
        [JsonProperty("name")]
        [Required]
        [Column("name")]
        [StringLength(maximumLength:16)]
        public string Name { get; set; }

        //所属学院
        [JsonProperty("deptname")]
        [Required]
        [Column("dept_name")]
        [StringLength(maximumLength: 16)]
        public string DeptName { get; set; }

    }
}
