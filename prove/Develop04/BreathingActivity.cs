namespace Develop04 {

    class BreathingActivity : Activity {

        
        public void breathingActivity() {
            displayDescription();
            int duration = getDuration();
            Console.Clear();
            readyMessage();
            breathingMessages(duration);
            endingDescription(duration, "Breathing");
            displayAnimation();
        }

        public void displayDescription() {
            Console.WriteLine("Welcome to the Breathing Activity.\n");
            Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n");
        }

        public void breathingMessages(int duration) {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            while (startTime < endTime) {
                startTime = DateTime.Now;
                breatheIn();
                Console.WriteLine();
                breatheOut();
                Console.WriteLine();
            }
        }

        public void breatheIn() {
            Console.WriteLine("Breathe in...");
            for (int i = 3; i > 0; i--) {
                Console.Write("\b \b");
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public void breatheOut() {
            Console.WriteLine("Breathe out...");
            for (int i = 3; i > 0; i--) {
                Console.Write("\b \b");
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}