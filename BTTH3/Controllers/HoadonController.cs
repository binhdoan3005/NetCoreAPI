using Microsoft.AspNetCore.Mvc;
using BTTH3.Models;
using System.Collections.Generic;

namespace BTTH3.Controllers
{
    public class HoadonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateTotal(List<string> tenHang, List<int> soLuong, List<double> donGia)
        {
            List<HoadonModel> danhSachHang = new List<HoadonModel>();
            double tongTien = 0;

            for (int i = 0; i < tenHang.Count; i++)
            {
                var hang = new HoadonModel
                {
                    TenHang = tenHang[i],
                    SoLuong = soLuong[i],
                    DonGia = donGia[i]
                };
                danhSachHang.Add(hang);
                tongTien += hang.ThanhTien;
            }

            ViewBag.DanhSachHang = danhSachHang;
            ViewBag.TongTien = tongTien;
            return View("Index");
        }
    }
}