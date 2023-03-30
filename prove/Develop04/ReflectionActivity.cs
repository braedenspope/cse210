namespace Develop04 {

    class ReflectionActivity : Activity {
        
        public void reflectionActivity() {
            displayDescription();
            int duration = getDuration();
            Console.Clear();
            readyMessage();
            string prompt = generatePrompt();
            displayPrompt(prompt);
            Console.Clear();
            displayQuestions(duration);
            endingDescription(duration, "Reflection");
            displayAnimation();
        }

        public void displayDescription() {
            Console.WriteLine("Welcome to the Reflection Activity.\n");
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");
        }

        public void displayPrompt(string prompt) {
            Console.WriteLine("Consider the following prompt:\n");
            Console.WriteLine("--- " + prompt + " ---\n");
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Now ponder on the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            for (int i = 5; i > 0; i--) {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public void displayQuestions(int duration) {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            while (startTime < endTime) {
                startTime = DateTime.Now;
                displayQuestion();
            }
        }

        public void displayQuestion() {
            List<string> questions = new List<string>();
            questions.Add("Why was this experience meaningful to you?");
            questions.Add("Have you ever done anything like this before?");
            questions.Add("How did you get started?");
            questions.Add("How did you feel when it was complete?");
            questions.Add("What made this time different than other times when you were not as successful?");
            questions.Add("What is your favorite thing about this experience?");
            questions.Add("What could you learn from this experience that applies to other situations?");
            questions.Add("What did you learn about yourself through this experience?");
            questions.Add("How can you keep this experience in mind in the future?");

            Random rand = new Random();
            int num = rand.Next(9);
            string question =  questions[num];

            Console.Write("> " + question + " ");
            displayAnimation();
            Console.WriteLine();
        }

        public string generatePrompt() {
            List<string> prompts = new List<string>();
            prompts.Add("Think of a time when you stood up for someone else.");
            prompts.Add("Think of a time when you did something really difficult.");
            prompts.Add("Think of a time when you helped someone in need.");
            prompts.Add("Think of a time when you did something truly selfless.");
            Random rand = new Random();
            int num = rand.Next(4);
            return prompts[num];
        }

    }
}