using System;

class Program
{
    static void Main(string[] args)
    {
        string grade = "";
        bool pass;
        Console.Write("What is your grade percentage? ");
        int percent =  Int32.Parse(Console.ReadLine());
        if (percent >= 90){
            grade = "A";
            pass = true;
        } else if (percent >= 80) {
            grade = "B";
            pass = true;
        } else if (percent >= 70){
            grade = "C";
            pass = true;
        } else if (percent >= 60){
            grade = "D";
            pass = false;
        } else {
            grade = "F";
            pass = false;
        }
        if (pass) {
            Console.Write("You passed!");
        } else {
            Console.Write("You failed.");
        }
        Console.WriteLine($" Your grade was {grade}.");
    }
}