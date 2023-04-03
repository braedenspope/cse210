namespace Develop05 {
    
    class EternalGoal : Goal {

        public EternalGoal(){}

        public EternalGoal(string name, string description, int value) {
            this.name = name;
            this.description = description;
            this.value = value;
        }

        public override void display() {
            Console.WriteLine("[ ] " + name + " (" + description + ")");
        }
    }
}