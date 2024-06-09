using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pos_api.Models
{
    [Table("purchaseorder")]
    public class PurchaseOrder
    {
        [Column("id")]
        [Key]
        public int id { get; set; }


        [Column("invoid")]
        public string invoid { get; set; }


        [Column("createdate")]
        public DateTime createdate { get; set; }
    }
}
