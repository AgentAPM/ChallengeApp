namespace ChallengeApp
{
    public class Statistics
    {
        public float Min { get; set; }
        public float Max { get; set; }
        public float Average { get; set; }
        public int Count { get; set; } = 0;
        public char AverageLetter
        {
            get
            {
                switch(Average) {
                    case var _ when Average > 80:
                        return 'A';
                    case var _ when Average > 60:
                        return 'B';
                    case var _ when Average > 40:
                        return 'C';
                    case var _ when Average > 20:
                        return 'D';
                    case var _ when Average > 0:
                        return 'E';
                    case var _ when Average <= 0:
                        return 'F';
                    default:
                        return '-';
                }
            }
        }


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
