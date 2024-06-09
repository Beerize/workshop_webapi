using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pos_api.Models
{
    [Table("purchasedetail")]
    public class PurchaseDetail
    {
        [Column("id")]
        [Key]
        public int id { get; set; }


        [Column("invoid")]
        public string invoid { get; set; }


        [Column("proid")]
        public string proid { get; set; }


        [Column("buyamount")]
        public int buyamount { get; set; }


        [Column("createdate")]
        public DateTime createdate { get; set; }
    }
}
