using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTTHMVC.Models;

namespace BTTHMVC.Controllers;
{

    public class BMIControllers : Controller
    {
         public ActionResult Index()
        {
            return View();
        }

        // Nhận dữ liệu từ form và xử lý tính BMI
        [HttpPost]
        public ActionResult Index(BMIModel model)
        {
            if (ModelState.IsValid)
            {
                // Tính BMI
                model.BMI = model.Weight / (model.Height * model.Height);

                // Xác định phân loại theo BMI
                if (model.BMI < 18.5)
                    model.Result = "Dưới cân";
                else if (model.BMI < 24.9)
                    model.Result = "Bình thường";
                else if (model.BMI < 29.9)
                    model.Result = "Thừa cân";
                else
                    model.Result = "Béo phì";

                // Gửi thông báo về View
                ViewBag.Message = $"Chỉ số BMI của bạn: {model.BMI:F2} - {model.Result}";
            }
            return View(model);
        }
    }
}
    
    


    