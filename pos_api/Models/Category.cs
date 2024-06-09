using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pos_api.Models
{
    [Table("category")]
    public class Category
    {
        [Column("catid")]
        [Key]
        public int catid { get; set; }


        [Column("catname")]
        public string catname { get; set; } = null!;
    }
}
