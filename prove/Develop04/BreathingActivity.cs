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
            displayCountdown(3);
        }

        public void breatheOut() {
            Console.WriteLine("Breathe out...");
            displayCountdown(3);
        }
    }
}