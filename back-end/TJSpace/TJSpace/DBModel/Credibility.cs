using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("credibility", Schema = "tjspace")]

    public class Credibility
    {
        //用户编号
        [Key]
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
<<<<<<< HEAD
        [StringLength(maximumLength: 20)]
=======
        [StringLength(maximumLength: 50)]
>>>>>>> tmp
        public string UserId { get; set; }

        //评价编号
        [Key]
        [JsonProperty("commentid")]
        [Required]
        [Column("comment_id")]
<<<<<<< HEAD
        [StringLength(maximumLength:20)]
=======
        [StringLength(maximumLength:50)]
>>>>>>> tmp
        public string CommentId { get; set; }

        //评价的种类
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
