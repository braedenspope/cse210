namespace Develop02
{
    public class Journal
    {
        List<Entry> entries = new List<Entry>();

        string[] prompts = {"What was the most interesting person I interacted with today?", "What was the best part of my day?", 
                            "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?",
                            "If I had one thing I could do over today, what would it be?", "What did I read in the scriptures today?",
                            "Where did I go today?", "What was I thankful for today?"};
        public Journal(){}

        public void run() {
            bool loop = true;
            Console.WriteLine("Welcome to the Journal Program!");
            while (loop) {
                Console.WriteLine("Please select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");
                string response = Console.ReadLine();
                if (response == "1") {
                    writeEntry();
                } else if (response == "2") {
                    displayJournal();
                } else if (response == "3") {
                    loadJournal();
                } else if (response == "4") {
                    saveJournal();
                } else if (response == "5") {
                    loop = false;
                    Console.WriteLine("Goodbye!");
                }
            }
            
        }

        public void writeEntry() {
            Random rand = new Random();
            int num = rand.Next(0,prompts.Length);
            Console.Write("\n" + prompts[num] + "\n> ");
            string response = Console.ReadLine();
            Entry entry = new Entry(prompts[num],response);
            entries.Add(entry);
        }

        public void displayJournal(){
            Console.WriteLine();
            foreach (Entry entry in entries) {
                Console.Write("Date: " + entry.date);
                Console.WriteLine(" Prompt: " + entry.prompt);
                Console.WriteLine(entry.response + "\n");
            }
        }

        public void saveJournal() {
            Console.WriteLine("What is the filename?");
            string filename = Console.ReadLine();
            using  (StreamWriter outputFile = new StreamWriter(filename)) {
                foreach (Entry entry in entries) {
                    outputFile.WriteLine(entry.date + "|" + entry.prompt + "|" + entry.response);
                }
            }
        }

        public void loadJournal() {
            List<Entry> newEntries = new List<Entry>();
            Console.WriteLine("What is the filename?");
            string filename = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines){
                string[] parts = line.Split("|");
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                Entry entry = new Entry(date,prompt,response);
                newEntries.Add(entry);
            }
            entries = newEntries;
        }
    }
}