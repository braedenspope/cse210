using System;

namespace FinalProject {
    class Program
    {
        static void Main(string[] args)
        {
            Character hero = new Character();
            int choice = 0;
            Console.WriteLine("Welcome to the Battle Dome!");
            while (choice != 6) {
                if (hero.getName() == null) {
                    Console.WriteLine("No character stored.");
                } else {
                    Console.WriteLine("Stored Character: " + hero.getName());
                }
                displayMenu();
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1) {
                    Console.Clear();
                    hero = createCharacter();
                } else if (choice == 2) {
                    Console.WriteLine();
                    hero.display();
                    Console.WriteLine();
                } else if (choice == 3) {
                    saveCharacter(hero);
                } else if (choice == 4) {
                    hero = loadCharacter();
                } else if (choice == 5) {
                    if (hero.getName() == null) {
                        Console.WriteLine("There is no character to play. Either make one or load one from a text file.");
                    } else {
                        Console.Clear();
                        fightMonster(hero);
                    }
                } else if (choice == 6) {
                    Console.WriteLine("Goodbye!");
                } else {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }

        static void fightMonster(Character hero) {
            Random rand = new Random();
            string monster = getMonster();
            Console.WriteLine(hero.getName() + " is fighting a " + monster + "!");
            int monsterHealth = getMonsterHealth(monster);
            while (monsterHealth > 0 && hero.getHealth() > 0) {
                Console.WriteLine(hero.getName() + "'s health: " + hero.getHealth());
                Console.WriteLine("The " + monster + "'s health: " + monsterHealth);
                Console.WriteLine("1. Heavy Attack");
                Console.WriteLine("2. Light Attack");
                Console.WriteLine("3. Retreat");
                Console.Write("What will " + hero.getName() + " do? ");
                int choice = Int32.Parse(Console.ReadLine());
                if (choice == 1) {
                    int rollToHit = rand.Next(1,20);
                    monsterHealth -= hero.performHeavyAttack(rollToHit, hero.getBaseDamage(), getMonsterArmor(monster));
                    hero.setHealth(hitCharacter(monster, hero));
                } else if (choice == 2) {
                    int rollToHit = rand.Next(1,20);
                    monsterHealth -= hero.performLightAttack(rollToHit, hero.getBaseDamage(), getMonsterArmor(monster));
                } else if (choice == 3) {
                    hero.setHealth(hero.getHealth());
                }
            }
            if (monsterHealth <= 0) {
                Console.WriteLine(hero.getName() + " defeated the " + monster + "!");
            } else {
                Console.WriteLine(hero.getName() + " was defeated by the" + monster + "!");
            }
            Thread.Sleep(5000);
            Console.Clear();
        }

        static int hitCharacter(string monster, Character hero) {
            Console.WriteLine();
            Random rand = new Random();
            int rollToHit = rand.Next(1,20) + 2;
            if (rollToHit >= hero.getArmorClass()) {
                Console.WriteLine("The " + monster + " hits " + hero.getName() + "!");
                return 2;
            } else {
                Console.WriteLine("The " + monster + " missed their attack on " + hero.getName() + ".");
                return 0;
            }
        }

        static int getMonsterArmor(string monster) {
            if (monster == "Goblin") {
                return 8;
            } else if (monster == "Kobold") {
                return 10;
            } else {
                return 12;
            }
        }

        static int getMonsterHealth(string monster) {
            if (monster == "Goblin") {
                return 10;
            } else if (monster == "Kobold") {
                return 12;
            } else {
                return 14;
            }
        }

        static string getMonster() {
            List<string> monsters = new List<string>();
            monsters.Add("Goblin");
            monsters.Add("Kobold");
            monsters.Add("Troglodyte");
            Random rand = new Random();
            string monster = monsters[rand.Next(monsters.Count)];
            return monster;
        }

        static Character loadCharacter() {
            Character hero = new Character();
            Console.Write("What is the filename of the goal file? ");
            string filename = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines) {
                string[] parts = line.Split(",");
                if (parts[0] == "Warrior") {
                    hero = new Warrior(parts[1],parts[2],parts[3],parts[4],parts[5],parts[6],parts[7],parts[8],parts[9]);
                } else if (parts[0] == "Hunter") {
                    hero = new Hunter(parts[1],parts[2],parts[3],parts[4],parts[5],parts[6],parts[7],parts[8],parts[9]);
                } else if (parts[0] == "Assassin") {
                    hero = new Assassin(parts[1],parts[2],parts[3],parts[4],parts[5],parts[6],parts[7],parts[8],parts[9]);
                } else if (parts[0] == "Guardian") {
                    hero = new Guardian(parts[1],parts[2],parts[3],parts[4],parts[5],parts[6],parts[7],parts[8],parts[9]);
                } else if (parts[0] == "Mage") {
                    hero = new Mage(parts[1],parts[2],parts[3],parts[4],parts[5],parts[6],parts[7],parts[8],parts[9]);
                }
            }
            return hero;
        }

        static void saveCharacter(Character hero) {
            Console.Write("What is the filename of the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(hero.getFileString());
            }
        }

        static Character createCharacter() {
            int choice = 0;
            Console.WriteLine("\nWelcome to the Character Creator!");
            Console.Write("What would you like to name this character? ");
            string name = Console.ReadLine();
            Console.WriteLine();
            while (choice == 0) {
                Console.WriteLine("\t1. Warrior (Medium Damage, Medium Defense)");
                Console.WriteLine("\t2. Hunter (Medium Damage, Medium Defense)");
                Console.WriteLine("\t3. Assassin (High Damage, Low Defense)");
                Console.WriteLine("\t4. Mage (High Damage, Low Defense)");
                Console.WriteLine("\t5. Guardian (Low Damage, High Defense)");
                Console.Write("Select Which class would you like " + name + "? ");
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1) {
                    Warrior warrior = new Warrior(name);
                    return warrior;
                } else if (choice == 2) {
                    Hunter hunter = new Hunter(name);
                    return hunter;
                } else if (choice == 3) {
                    Assassin assassin = new Assassin(name);
                    return assassin;
                } else if (choice == 4) {
                    Mage mage = new Mage(name);
                    return mage;
                } else if (choice == 5) {
                    Guardian guardian = new Guardian(name);
                    return guardian;
                } else {
                    Console.WriteLine("Please select one of the options listed.");
                    choice = 0;
                }
            }
            return new Character();
        }

        static void displayMenu() {
            Console.WriteLine("\t1. Create a Character");
            Console.WriteLine("\t2. Display the current Character");
            Console.WriteLine("\t3. Save the current Character");
            Console.WriteLine("\t4. Load the current Character");
            Console.WriteLine("\t5. Fight a monster");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select an option: ");
        }
    }
}
