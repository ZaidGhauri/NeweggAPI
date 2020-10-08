using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newegg.Marketplace.SDK;
using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Order;
using Newegg.Marketplace.SDK.Order.Model;

namespace NeweggAssignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            APIConfig config = APIConfig.FromJsonFile("newegg");
            APIClient client = new APIClient(config);
            OrderCall ordercall = new OrderCall(client);
            var requestModel = new GetOrderInformationRequest()
            {
                OperationType = "GetOrderInfoRequest",
                RequestBody = new GetOrderInformationRequestBody() {
                    PageIndex = 0,
                    PageSize = 20,
                    RequestCriteria = new GetOrderInformationRequestCriteria() {
                        
                    }
                }
            };
            var response = ordercall.GetOrderInformation(304, requestModel);
            return View(response);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
