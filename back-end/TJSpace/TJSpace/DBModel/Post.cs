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
        //用户编号
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
        [StringLength(maximumLength: 50)]
        public string UserId { get; set; }

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

        //发布时间
        [JsonProperty("date")]
        [Required]
        [Column("date", TypeName = "date")]
        public DateTime Date{get; set;}

        //当前帖子最大楼层数
        [JsonProperty("floor")]
        [Required]
        [Column("floor", TypeName = "int(11)")]
        public int Floor { get; set; }

        //评价的种类
        [JsonProperty("usefulnum")]
        [Required]
        [Column("useful_num", TypeName = "int(11)")]
        public int UsefulNum { get; set; }

        //评价的种类
        [JsonProperty("uselessnum")]
        [Required]
        [Column("useless_num", TypeName = "int(11)")]
        public int UselessNum { get; set; }

    }
}
