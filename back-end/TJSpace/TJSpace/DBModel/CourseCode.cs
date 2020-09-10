<<<<<<< HEAD
﻿using System;
=======
﻿
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
    [Table("course_code", Schema = "tjspace")]

    public class CourseCode
    {
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

        //课程名
        [JsonProperty("title")]
        [Required]
        [Column("title")]
        [StringLength(maximumLength: 16)]
        public string Title { get; set; }


    }
}
