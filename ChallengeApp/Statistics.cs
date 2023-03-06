namespace ChallengeApp
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; } = 0;
        public float Average { 
            get
            {
                if (Count == 0) return float.NaN;

                return Sum / Count;
            }
        }
        public char AverageLetter
        {
            get
            {
                switch (Average)
                {
                    case var _ when Average > 90:
                        return 'A';
                    case var _ when Average > 70:
                        return 'B';
                    case var _ when Average > 50:
                        return 'C';
                    case var _ when Average > 30:
                        return 'D';
                    case var _ when Average > 10:
                        return 'E';
                    case var _ when Average <= 10:
                        return 'F';
                    default:
                        return '-';
                }
            }
        }


        public Statistics()
        {
            Count = 0;
            Sum = 0;
            Min = float.MaxValue;
            Max = float.MinValue;
        }
        public void AddGrade(float grade)
        {
            Count++;
            Sum += grade;
            Min = Math.Min(Min, grade);
            Max = Math.Max(Max, grade);
        }
    }
}
