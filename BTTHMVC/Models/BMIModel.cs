using System.ComponentModel.DataAnnotations;

namespace BMI.Models
{
    public class BMIModel
    {
        [Required(ErrorMessage = "Vui lòng nhập cân nặng.")]
        [Range(1, 500, ErrorMessage = "Cân nặng phải trong khoảng từ 1 đến 500 kg.")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chiều cao.")]
        [Range(0.5, 3, ErrorMessage = "Chiều cao phải trong khoảng từ 0.5 đến 3 mét.")]
        public float Height { get; set; }

        public float BMI { get; set; }
        public string Result { get; set; }
    }
}
