namespace Develop05 {
    
    class Goal {

        protected string name;
        protected string description;

        protected int value;

        public Goal() {}

        public string getName() {
            return name;
        }

        public virtual int getScore() {
            return value;
        }

        public virtual void initialize() {
            Console.Write("What is the name of your goal? ");
            name = Console.ReadLine();
            Console.Write("What is the description of it? ");
            description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            value = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
        }
        
        public virtual int accomplish() {
            Console.WriteLine("Congratulations! You have earned " + getScore() + " points");
            return getScore();
        }

        public virtual void display() {
            Console.WriteLine( name + " (" + description + ")");
        }

        public virtual string getFileString() {
            return this.GetType() + "," + name  + "," + description + "," + value;
        }
    }
}