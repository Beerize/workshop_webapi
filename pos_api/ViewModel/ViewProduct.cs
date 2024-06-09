namespace pos_api.ViewModel
{
    public class ViewProduct
    {
        public ViewProduct()
        {

        }

        public string id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public int stAmount { get; set; }

        public string imgPic { get; set; }

        public int buyAmount { get; set; }

        public int catid { get; set; }
    }
}
