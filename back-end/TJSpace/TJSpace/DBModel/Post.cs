using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("post", Schema = "tjspace")]

    public class Post
    {
        //贴子编号
        [Key]
        [JsonProperty("postid")]
        [Required]
        [Column("post_id")]
        [StringLength(maximumLength: 50)]
        public string PostId { get; set; }

        //贴子标题
        [JsonProperty("title")]
        [Required]
        [Column("title")]
        [StringLength(maximumLength: 200)]
        public string Title { get; set; }

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

        //发帖时间
        [JsonProperty("date")]
        [Required]
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
