using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pos_api.Data;
using pos_api.ViewModel;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using pos_api.Models;

namespace pos_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly APIContext _context;

        public ProductController(ILogger<ProductController> logger, APIContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        [Route("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            var cate = await _context.Category.ToListAsync();
            return Ok(cate);
        }



        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            //List<ViewProduct> myproducts = new List<ViewProduct>();

            //myproducts.Add(new ViewProduct()
            //{
            //    id = "AAZ01",
            //    name = "BAG",
            //    price = 350,
            //    stAmount = 3,
            //    imgPic = "https://images.unsplash.com/photo-1584917865442-de89df76afd3?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8QmFnfGVufDB8fDB8fHww"
            //});

            //myproducts.Add(new ViewProduct()
            //{
            //    id = "AAZ02",
            //    name = "BAG2",
            //    price = 220,
            //    stAmount = 1,
            //    imgPic = "https://plus.unsplash.com/premium_photo-1680373109883-47a3617e9acd?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8QmFnfGVufDB8fDB8fHww"
            //});

            //myproducts.Add(new ViewProduct()
            //{
            //    id = "AAZ03",
            //    name = "BAG3",
            //    price = 120,
            //    stAmount = 5,
            //    imgPic = "https://images.unsplash.com/photo-1584917865442-de89df76afd3?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8QmFnfGVufDB8fDB8fHww"
            //});

            var listProduct = new List<ViewProduct>();
            var myproducts = await _context.Product.ToListAsync();
            if (myproducts.Count > 0)
            {
                for (int i=0; i < myproducts.Count; i++)
                {
                    listProduct.Add(new ViewProduct {
                        id = myproducts[i].id,
                        name = myproducts[i].name,
                        price = myproducts[i].price,
                        stAmount = myproducts[i].stAmount,
                        imgPic = myproducts[i].imgPic,
                        catid = myproducts[i].catid,
                        buyAmount = 0

                    });
                }
            }

            return Ok(listProduct);
        }



        [HttpPost]
        [Route("PostBuyProduct")]
        public async Task<IActionResult> PostBuyProduct([FromBody] List<ViewPostBuy> data)
        {
            try
            {
                Random generator = new Random();
                String r = generator.Next(0, 1000000).ToString("D6");

                var createOrder = new PurchaseOrder();
                createOrder.invoid = "INV-" + r;
                createOrder.createdate = DateTime.Now;
                _context.Add(createOrder);
                await _context.SaveChangesAsync();

                string invoidOk = createOrder.invoid;


                for (int i=0; i < data.Count; i++)
                {
                    var createOrderDetail = new PurchaseDetail();
                    createOrderDetail.invoid = invoidOk;
                    createOrderDetail.createdate = DateTime.Now;
                    createOrderDetail.proid = data[i].productid;
                    createOrderDetail.buyamount = data[i].buyAmount;
                    _context.Add(createOrderDetail);
                    await _context.SaveChangesAsync();

                    var olddata = _context.Product.Where(x => x.id == data[i].productid).FirstOrDefault();
                    olddata.stAmount = olddata.stAmount - data[i].buyAmount;
                    _context.Update(olddata);
                    await _context.SaveChangesAsync();


                }
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, message = "fail" });
            }

            return Ok(new {status = true, message = "success"});
        }




    }
}
