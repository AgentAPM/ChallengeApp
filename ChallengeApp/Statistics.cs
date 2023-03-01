namespace ChallengeApp
{
    public class Statistics
    {
        public float Min { get; set; }
        public float Max { get; set; }
        public float Average { get; set; }

        public Statistics()
        {
            Min = float.MaxValue;
            Max = float.MinValue;
            Average = 0;
        }
        public Statistics(float min, float max, float average)
        {
            this.Min = min;
            this.Max = max;
            this.Average = average;
        }
    }
}
