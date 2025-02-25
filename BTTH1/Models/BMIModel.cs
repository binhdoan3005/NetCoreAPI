namespace BTTH1;

public class BMIModel
{
    public double Weight { get; set; }
    public double Height { get; set; }

    public double CalculateBMI()
    {
        if (Height > 10)
        {
            Height /= 100;
        }

        if (Height <= 0)
            return 0;

        return Weight / (Height * Height);
    }

    public string GetBMICategory()
    {
        double bmi = CalculateBMI();
        if (bmi < 18.5)
            return "Gầy";
        else if (bmi < 24.9)
            return "Bình thường";
        else if (bmi < 29.9)
            return "Thừa cân";
        else
            return "Béo phì";
    }
}
