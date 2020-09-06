﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{

    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("course", Schema = "tjspace")]

    public class Course
    {
        //课程编号
        [Key]
        [JsonProperty("courseid")]
        [Required]
        [Column("course_id")]
        [StringLength(maximumLength: 50)]
        public string CourseId { get; set; }

        //开课学院
        [Key]
        [JsonProperty("deptname")]
        [Required]
        [Column("dept_name")]
        [StringLength(maximumLength:16)]
        public string DeptName { get; set; }

        //课程学分
        [JsonProperty("credits")]
        [Required]
        [Column("credits",TypeName="int(11)")]
        public int Credits { get; set; }

        //课程简介
        [JsonProperty("intro")]
        [Required]
        [Column("intro")]
        [StringLength(maximumLength: 200)]
        public string Intro { get; set; }
    }
}
