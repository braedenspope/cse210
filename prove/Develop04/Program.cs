using System;

namespace Develop04 {
    class Program
{
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice == 0) {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("\t1. Start breathing activity");
                Console.WriteLine("\t2. Start reflecting activity");
                Console.WriteLine("\t3. Start listing activity");
                Console.WriteLine("\t4. Quit");
                Console.Write("Select a choice from the menu: ");
                choice = Int32.Parse(Console.ReadLine());
                if (choice != 1 && choice != 2 && choice != 3 && choice != 4) {
                    Console.WriteLine("Please enter a valid choice.");
                    Thread.Sleep(5000);
                    Console.Clear();
                } else if (choice == 1) {
                    Console.Clear();
                    BreathingActivity activity = new BreathingActivity();
                    activity.breathingActivity();
                    choice = 0;
                    Console.Clear();
                } else if (choice == 2) {
                    Console.Clear();
                    ListingActivity activity = new ListingActivity();
                    activity.listingActivity();
                    choice = 0;
                    Console.Clear();
                } else if (choice == 3) {
                    Console.Clear();
                    ReflectionActivity activity = new ReflectionActivity();
                    activity.reflectionActivity();
                    choice = 0;
                    Console.Clear();
                } 
            }
            
        }
    }
}
