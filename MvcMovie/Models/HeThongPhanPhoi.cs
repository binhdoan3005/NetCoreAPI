using System.ComponentModel.DataAnnotations;
namespace MvcMovie;

public class HeThongPhanPhoi
{  
    [Key]
    public string MaHTPP { get; set; }
    public string TenHTPP { get; set; }
    public List<DaiLy> DaiLys { get; set; } = new List<DaiLy>();
}
