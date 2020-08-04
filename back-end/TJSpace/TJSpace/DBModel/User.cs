using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("user", Schema = "tjspace")]

    public class User
    {
        //用户编号
        [Key]
        [JsonProperty("userid")]
        [Required]
        [Column("user_id")]
        [StringLength(maximumLength: 20)]
        public string UserId { get; set; }

        //用户昵称
        [JsonProperty("nickname")]
        [Required]
        [Column("nickname")]
        [StringLength(maximumLength: 20)]
        public string NickName { get; set; }

        //用户性别
        [JsonProperty("gentle")]
        [Required]
        [Column("gentle",TypeName ="int(11)")]
        public int Gentle { get; set; }

        //用户昵称
        [JsonProperty("phonenumber")]
        [Required]
        [Column("phonenumber")]
        [StringLength(maximumLength: 20)]
        public string PhoneNumber { get; set; }

        //所在专业
        [JsonProperty("majorid")]
        [Required]
        [Column("major_id")]
        [StringLength(maximumLength: 10)]
        public string MajorId { get; set; }

        //入学年份
        [JsonProperty("year")]
        [Required]
        [Column("year", TypeName = "int(11)")]
        public int Year { get; set; }

        //用户学历
        [JsonProperty("degree")]
        [Required]
        [Column("degree", TypeName = "int(11)")]
        public int Degree { get; set; }



    }
}
