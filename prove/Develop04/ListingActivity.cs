namespace Develop04 {

    class ListingActivity : Activity {
        

        public void listingActivity() {
            displayDescription();
            int duration = getDuration();
            Console.Clear();
            readyMessage();
            Console.Clear();
            string prompt = generatePrompt();
            displayPrompt(prompt);
            receiveInput(duration);
            endingDescription(duration, "Listing");
            displayAnimation();
        }

        public void displayDescription() {
            Console.WriteLine("Welcome to the Listing Activity.\n");
            Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");
        }

        public void displayPrompt(string prompt) {
            Console.WriteLine("List as many responses you can to the following prompt:");
            Console.WriteLine("--- " + prompt + " ---\n");
            Console.Write("You may begin in: ");
            for (int i = 5; i > 0; i--) {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public void receiveInput(int duration) {
            int count = 0;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            while (startTime < endTime) {
                startTime = DateTime.Now;
                Console.Write("> ");
                string answer = Console.ReadLine();
                count++;
                Console.WriteLine();
            }
            Console.WriteLine("You listed " + count + " items!\n");
        }

        public string generatePrompt() {
            List<string> prompts = new List<string>();
            prompts.Add("Who are people that you appreciate?");
            prompts.Add("What are personal strengths of yours?");
            prompts.Add("Who are people that you have helped this week?");
            prompts.Add("When have you felt the Holy Ghost this month?");
            prompts.Add("Who are some of your personal heroes?");
            Random rand = new Random();
            int num = rand.Next(5);
            return prompts[num];
        }
    }
}