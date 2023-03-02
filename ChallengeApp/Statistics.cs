namespace ChallengeApp
{
    public class Statistics
    {
        public float Min { get; set; }
        public float Max { get; set; }
        public float Average { get; set; }
        public char AverageLetter
        {
            get
            {
                switch(Average) {
                    case var averate when Average > 80:
                        return 'A';
                        break;
                    case var averate when Average > 60:
                        return 'B';
                        break;
                    case var averate when Average > 40:
                        return 'C';
                        break;
                    case var averate when Average > 20:
                        return 'D';
                        break;
                    case var averate when Average > 0:
                        return 'E';
                        break;
                    case var averate when Average <= 0:
                        return 'F';
                        break;
                    default:
                        return '_';
                        break;
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
