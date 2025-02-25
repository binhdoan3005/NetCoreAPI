using Microsoft.AspNetCore.Mvc;
using BTTH2.Models;

namespace BTTH2.Controllers
{
    public class GPAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateGPA(double scoreA, double scoreB, double scoreC)
        {
            double finalGPA = (scoreA * 0.6) + (scoreB * 0.3) + (scoreC * 0.1);
            ViewBag.ScoreA = scoreA;
            ViewBag.ScoreB = scoreB;
            ViewBag.ScoreC = scoreC;
            ViewBag.FinalGPA = finalGPA;
            return View("Index");
        }
    }
}