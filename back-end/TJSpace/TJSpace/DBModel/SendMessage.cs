using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("send_message", Schema = "tjspace")]

    public class SendMessage
    {
        //消息编号
        [Key]
        [JsonProperty("messageid")]
        [Required]
        [Column("message_id")]
        [StringLength(maximumLength: 16)]
        public string MessageId { get; set; }

        //用户id
        [JsonProperty("from")]
        [Required]
        [Column("from")]
<<<<<<< HEAD
        [StringLength(maximumLength:16)]
=======
        [StringLength(maximumLength:50)]
>>>>>>> tmp
        public string From { get; set; }

        //消息内容
        [JsonProperty("content")]
        [Required]
        [Column("content")]
        [StringLength(maximumLength: 50)]
        public string Content { get; set; }

        //用户id
        [JsonProperty("to")]
        [Required]
        [Column("to")]
<<<<<<< HEAD
        [StringLength(maximumLength: 16)]
=======
        [StringLength(maximumLength: 50)]
>>>>>>> tmp
        public string To { get; set; }

    }
}
