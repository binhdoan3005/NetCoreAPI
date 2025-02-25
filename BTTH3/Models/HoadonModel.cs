namespace BTTH3.Models
{
    public class HoadonModel
    {
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien => SoLuong * DonGia;
    }
}