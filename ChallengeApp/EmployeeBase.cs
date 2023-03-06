namespace ChallengeApp
{

    public abstract class EmployeeBase : IEmployee
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public event GradeAddedDelegate? GradeAdded;
        protected void EmitEventGradeAdded()
        {
            if(GradeAdded != null) GradeAdded(this, EventArgs.Empty);
        }
        public EmployeeBase(string name, string lastName) { 
            Name = name;
            LastName = lastName;
        }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public virtual string Personals
        {
            get
            {
                return $"{this.Name} {this.LastName}";
            }
        }

        public abstract Statistics GetStatistics();

        public abstract void GiveGrade(float grade);

        public abstract void GiveGrade(double grade);

        public abstract void GiveGrade(int grade);

        public abstract void GiveGrade(long grade);

        public abstract void GiveGrade(string grade);

        public abstract void GiveGrade(char grade);
    }
}
