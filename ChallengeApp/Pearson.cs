namespace ChallengeApp
{
    public abstract class Pearson
    {
        public Pearson(string name, string lastName, char sex)
        {
            this.Name = name;
            this.LastName = lastName;
            Sex = sex;
        }
        public Pearson(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;

            if(name == "")
            {
                Sex = '?';
            }
            else if (name.Last().Equals('a'))
            {
                Sex = 'K';
            } 
            else
            {
                Sex = 'M';
            }
            
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public char Sex { get; private set; }

        public string GetPersonals()
        {
            string summary = $"{this.Name} {this.LastName} ({Sex})";
            return summary;
        }
    }
}
