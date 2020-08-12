using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("reply", Schema = "tjspace")]

    public class Reply
    {
        //贴子编号
        [Key]
        [JsonProperty("replyid")]
        [Required]
        [Column("reply_id")]
        [StringLength(maximumLength: 50)]
        public string ReplyId { get; set; }

        //贴子内容
        [JsonProperty("content")]
        [Required]
        [Column("content")]
        [StringLength(maximumLength: 200)]
        public string Content { get; set; }

        //用户编号
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
        [StringLength(maximumLength: 50)]
        public string UserId { get; set; }

        //贴子编号
        [JsonProperty("postid")]
        [Required]
        [Column("post_id")]
        [StringLength(maximumLength: 50)]
        public string PostId { get; set; }

        //回帖时间
        [JsonProperty("date")]
        [Required]
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }

        //回帖的楼层
        [JsonProperty("floor")]
        [Required]
        [Column("floor", TypeName = "int(11)")]
        public int Floor { get; set; }

        //回帖的种类
        [JsonProperty("type")]
        [Required]
        [Column("type", TypeName = "int(11)")]
        public int Type { get; set; }
    }
}
