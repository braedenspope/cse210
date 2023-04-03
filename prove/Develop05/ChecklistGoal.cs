namespace Develop05 {

    class ChecklistGoal : Goal {

        private int timesCompleted;
        private int timesNeeded;

        public ChecklistGoal() {}
        public ChecklistGoal(string name, string description, int value, int timesNeeded, int timesCompleted){
            this.name = name;
            this.description = description;
            this.value = value;
            this.timesNeeded = timesNeeded;
            this.timesCompleted = timesCompleted;
        }
        public override void initialize() {
            Console.Write("What is the name of your goal? ");
            name = Console.ReadLine();
            Console.Write("What is the description of it? ");
            description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            value = Int32.Parse(Console.ReadLine());
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            timesNeeded = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        public override int getScore()
        {
            int score = 0;
            if (timesCompleted == timesNeeded) {
                score += timesNeeded * value;
            }
            return score + value;
        }

        public override int accomplish()
        {
            timesCompleted++;
            return base.accomplish();
        }

        public override void display()
        {
            if (timesCompleted == timesNeeded) {
                Console.Write("[X] ");
            } else {
                Console.Write("[ ] ");
            }
            Console.WriteLine(name + " (" + description + ") -- Currently completed: " + timesCompleted + "/" + timesNeeded);
        }

        public override string getFileString()
        {
            return this.GetType() + "," + name  + "," + description + "," + value + "," + timesNeeded + "," + timesCompleted;
        }
    }
}