namespace Develop05 {
    
    class SimpleGoal : Goal {

        private bool completed;

        public SimpleGoal() {}
        public SimpleGoal(string name, string description, int value, bool completed) {
            this.name = name;
            this.description = description;
            this.value = value;
            this.completed = completed;
        }

        public override int accomplish()
        {
            completed = true;
            return base.accomplish();
        }

        public override void display()
        {
            if (completed) {
                Console.Write("[X] ");
            } else {
                Console.Write("[ ] ");
            }
            Console.WriteLine(name + " (" + description + ")");
        }

        public override string getFileString()
        {
            return this.GetType() + "," + name  + "," + description + "," + value + "," + completed;
        }
    }
}