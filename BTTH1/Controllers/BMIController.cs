using Microsoft.AspNetCore.Mvc;

namespace BTTH1.Controllers;

public class BMIController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(double weight, double height)
    {
        if (height <= 0)
        {
            ViewBag.Result = "Chiều cao phải lớn hơn 0.";
            return View();
        }

        BMIModel bmi = new BMIModel
        {
            Weight = weight,
            Height = height
        };

        double bmiValue = bmi.CalculateBMI();
        string category = bmi.GetBMICategory();

        ViewBag.Result = $"Chỉ số BMI của bạn: {bmiValue:F2} - {category}";
        return View();
    }
}
