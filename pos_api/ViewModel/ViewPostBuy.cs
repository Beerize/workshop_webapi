using System.ComponentModel.DataAnnotations;

namespace pos_api.ViewModel
{
    public class ViewPostBuy
    {
        [Required(ErrorMessage = "ชื่อสินค้า ห้ามว่าง")]
        public string productid { get; set; }

        [Required(ErrorMessage = "จำนวน ห้ามว่าง")]
        [Range(1, 9999, ErrorMessage = "ข้อมูลจำนวน ไม่ถูกต้อง")]
        public int buyAmount { get; set; }
    }
}
