namespace BTTH2.Models
{
    public class GPAModel
    {
        public double ScoreA { get; set; }
        public double ScoreB { get; set; }
        public double ScoreC { get; set; }
        public double FinalGPA => (ScoreA * 0.6) + (ScoreB * 0.3) + (ScoreC * 0.1);
    }
}