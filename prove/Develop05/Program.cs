using System;

namespace Develop05 {
    class Program
    {
        static void Main(string[] args)
        {
            List<Goal> goals = new List<Goal>();
            int score = 0;
            int choice = 0;
            while (choice != 6) {
                Console.WriteLine("\nYou have " + score + " points.\n");
                displayMenu();
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1) {
                    Goal goal = createGoal();
                    goals.Add(goal);
                } else if (choice == 2) {
                    displayGoals(goals);
                } else if (choice == 3) {
                    saveGoals(score, goals);
                } else if (choice == 4) {
                    Tuple<List<Goal>,int> data = loadGoals();
                    goals = data.Item1;
                    score = data.Item2;
                } else if (choice == 5) {
                    score += completeEvent(goals);
                    Console.WriteLine("You now have " + score + " points.");
                }
            }
        }

        static int completeEvent(List<Goal> goals) {
            int score = 0;
            int goal = 0;
            
            Console.WriteLine("The goals are:");
            for (int i = 1; i <= goals.Count; i++) {
                Console.Write(i + ":");
                Console.WriteLine(goals[i-1].getName());
            }
            Console.Write("What goal did you accomplish? ");
            goal = Int32.Parse(Console.ReadLine()) - 1;
            score = goals[goal].accomplish();
            return score;
        }

        static Tuple<List<Goal>, int> loadGoals() {
            List<Goal> goals = new List<Goal>();
            int score = 0;
            Console.Write("What is the filename of the goal file? ");
            string filename = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines) {
                string[] parts = line.Split(",");
                if (parts.Length == 1) {
                    score = Int32.Parse(parts[0]);
                }
                if (parts[0] == "EternalGoal") {
                    EternalGoal goal = new EternalGoal(parts[1], parts[2], Int32.Parse(parts[3]));
                    goals.Add(goal);
                } else if (parts[0] == "SimpleGoal") {
                    SimpleGoal goal = new SimpleGoal(parts[1], parts[2], Int32.Parse(parts[3]), bool.Parse(parts[4]));
                    goals.Add(goal);
                } else if (parts[0] == "ChecklistGoal") {
                    ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], Int32.Parse(parts[3]), Int32.Parse(parts[4]), Int32.Parse(parts[5]));
                    goals.Add(goal);
                }
            }
            return Tuple.Create(goals,score);
        }

        static void saveGoals(int score, List<Goal> goals) {
            Console.Write("What is the filename of the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(score);
                foreach (Goal goal in goals) {
                    string data = goal.getFileString();
                    outputFile.WriteLine(data);
                }
            }
        }

        static void displayGoals(List<Goal> goals) {
            int count = 1;
            foreach (Goal goal in goals) {
                Console.Write(count + ". ");
                goal.display();
                count++;
            }
            Console.WriteLine();
        }

        static Goal createGoal() {
            int num = 0;
            while (num != 1 || num != 2 || num != 3){
                displayGoalOptions();
                num = Int32.Parse(Console.ReadLine());
                if (num == 1) {
                    SimpleGoal goal = new SimpleGoal();
                    goal.initialize();
                    return goal;
                } else if (num == 2) {
                    EternalGoal goal = new EternalGoal();
                    goal.initialize();
                    return goal;
                } else if (num == 3) {
                    ChecklistGoal goal = new ChecklistGoal();
                    goal.initialize();
                    return goal;
                } else {
                    Console.WriteLine("Please select a valid goal option.");
                }
            }
        return new Goal();
        }

         static void displayMenu() {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select a choice from the menu: ");
        }

        static void displayGoalOptions() {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("\t1. Simple Goal");
            Console.WriteLine("\t2. Eternal Goal");
            Console.WriteLine("\t3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
        }
    }
}
