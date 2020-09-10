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
    [Table("mark", Schema = "tjspace")]

    public class Mark
    {
        //用户编号
        [Key]
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
<<<<<<< HEAD
        [StringLength(maximumLength: 20)]
        public string UserId { get; set; }

        //回复编号
        [Key]
        [JsonProperty("replyid")]
        [Required]
        [Column("reply_id")]
        [StringLength(maximumLength:20)]
        public string ReplyId { get; set; }

=======
        [StringLength(maximumLength: 50)]
        public string UserId { get; set; }

>>>>>>> tmp
        //贴子编号
        [Key]
        [JsonProperty("postid")]
        [Required]
<<<<<<< HEAD
        [Column("post_id",TypeName ="int(11)")]
        public int PostId { get; set; }
=======
        [Column("post_id")]
        [StringLength(maximumLength: 50)]
        public string PostId { get; set; }
>>>>>>> tmp

        //评价种类
        [JsonProperty("type")]
        [Required]
        [Column("type",TypeName ="int(11)")]
        public int Type { get; set; }

        //发布时间
        [JsonProperty("date")]
        [Required]
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }

    }
}
