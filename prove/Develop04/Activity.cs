namespace Develop04 {

    class Activity {

        public void readyMessage() {
            Console.WriteLine("Get ready...");
            displayAnimation();
            Console.WriteLine("\n");
        }

        public void endingDescription(int duration, string activity) {
            Console.WriteLine("Well done!");
            Thread.Sleep(2000);
            Console.WriteLine("You have completed another " + duration + " seconds of the " + activity + " Activity.");
        }

        public int getDuration() {
            Console.Write("How long, in seconds, would you like for your session? ");
            int duration = Int32.Parse(Console.ReadLine());
            return duration;
        }

        public void displayCountdown(int num) {
            for (int i = num; i > 0; i--) {
                Console.Write("\b \b");
                Console.Write(i);
                Thread.Sleep(1000);
            }
        }

        public void displayAnimation() {
            List<string> animation = new List<string>();
            animation.Add("|");
            animation.Add("/");
            animation.Add("-");
            animation.Add("\\");
            animation.Add("|");
            animation.Add("/");
            animation.Add("-");
            animation.Add("\\");

            foreach (string s in animation) {
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}