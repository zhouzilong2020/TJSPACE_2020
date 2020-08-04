using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("major", Schema = "tjspace")]

    public class Major
    {
        //专业编号
        [Key]
        [JsonProperty("majorid")]
        [Required]
        [Column("major_id")]
        [StringLength(maximumLength: 10)]
        public string MajorId { get; set; }

        //专业名
        [JsonProperty("majorname")]
        [Required]
        [Column("major_name")]
        [StringLength(maximumLength: 20)]
        public string MajorName { get; set; }
    }
}
