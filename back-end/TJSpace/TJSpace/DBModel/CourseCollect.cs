﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("course_collect", Schema = "tjspace")]
    public class CourseCollect
    {
        //用户编号
        [Key]
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
        [StringLength(maximumLength: 50)]
        public string UserId { get; set; }

        //课程编号
        [Key]
        [JsonProperty("courseid")]
        [Required]
        [Column("course_id")]
        [StringLength(maximumLength: 50)]
        public string CourseId { get; set; }

        //教师编号
        [Key]
        [JsonProperty("teacherid")]
        [Required]
        [Column("teacher_id")]
        [StringLength(maximumLength: 50)]
        public string TeacherId { get; set; }
    }
}