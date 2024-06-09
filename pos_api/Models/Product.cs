using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pos_api.Models
{
    [Table("product")]
    public class Product
    {
        [Column("id")]
        [Key]
        public string id { get; set; }

        [Column("name")]
        public string name { get; set; }


        [Column("price")]
        public decimal price { get; set; }

        [Column("stAmount")]
        public int stAmount { get; set; }


        [Column("imgPic")]
        public string imgPic { get; set; }


        [Column("catid")]
        public int catid { get; set; }


    }
}
