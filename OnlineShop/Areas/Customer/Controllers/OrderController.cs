using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using OnlineShop.Models;
using OnlineShop.Models.Repositories;
using OnlineShop.Utility;

namespace OnlineShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {

            List<Product> products = HttpContext.Session.Get<List<Product>>("products");



            //OnlineStoreos123@gmail.com
            //000001234500000
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Online Store", "OnlineStoreos123@gmail.com"));
            message.To.Add(new MailboxAddress(order.Name.ToString(), order.Email.ToString()));
            message.Subject = "Test Online MAil";
            var htmlString = " Hello Thank you for buying from our site, we will deliver your order as soon as possible <br/>";

            htmlString += @"<div>
                 <table>
                    <thead>
                        <tr>
                            
                            <th>Name</th>
                            <th>Price</th>
                            <th>Product Type</th>
                            <th>Color</th>
                            <th></th>
                        </tr>
                    </thead>";

            htmlString += @"<tbody>";
           


            foreach (var item in products)
            {
                htmlString += @"<tr>
                    
                       <td>"+ item.Name + "</td>"+
   
                      "<td>" + item.Price+" </td>"+
   
                      "<td>"+item.ProductTypes.ProductType +" </td>"+
   
                      "<td>"+ item.ProductColor +" </td>"+
                "</tr>";

            }
            htmlString += @"</tbody>";

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlString
            };


        
            
            using(var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("OnlineStoreos123@gmail.com", "000001234500000");
                client.Send(message);
                client.Disconnect(true);
            }


            
            if(products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.Id;
                    
                    order.OrderDetails.Add(orderDetails);
                }
               
            }

            
            order.OrderNo = GetOrderNo();
            orderRepository.Add(order);
            HttpContext.Session.Set("products", new List<Product>());
            return RedirectToAction("ThankYou");
           
        }

        public string GetOrderNo()
        {
            int rowCount = orderRepository.List().Count()+1;
            return rowCount.ToString("000");
        }

        
        public IActionResult ThankYou()
        {
            
            return View();
        }
    }
}
